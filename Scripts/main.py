import pandas as pd
import numpy as np
import math
import os


# Retorna o nome do diretório dentro 'root' que contenha a String 'project' em seu nome
def get_project_name(root: str, project: str) -> str:
    for d in os.listdir(root):
        if project in d:
            return d
    raise NameError(f'Project {project} not found in specified directory.')


# Retorna o caminho de 'root' concatenado com o nome do projeto e o 'path' provido
def get_logs_path(root: str, project: str, path: str) -> str:
    project = get_project_name(root, project)
    path = fr'{root}\{project}\{path}'
    return path


# Retorna o nome de todos os arquivos '.csv' de um diretório especificado
def get_directory_csvs(directory_path: str) -> list[str]:
    directories = []
    for file in os.listdir(directory_path):
        file_extension = file.split('.')[-1]
        if file_extension == 'csv':
            directories.append(file)
    return directories


# Mapeia todos os arquivos '.csv' de um diretório para um dicionário
# Onde as chaves são o nome do arquivo e o valor é um DataFrame do csv em questão
def csvs_to_dataframe_dictionary(path: str, csvs: list[str]) -> dict[str, pd.DataFrame]:
    d = {}
    for csv in csvs:
        d[csv] = pd.read_csv(fr'{path}\{csv}', sep=';')
    return d


# Dado um dicionário de DataFrames, retorna um novo dicionário de DataFrames com apenas as colunas desejadas
def format_dataframe_dictionary(data: dict[str, pd.DataFrame], columns: list[str]) -> dict[str, pd.DataFrame]:
    formatted_data = {}
    for k, v in data.items():
        formatted_data[k] = v[columns]
    return formatted_data


# Retorna a String fornecida sem vírgulas
def format_number(number: str) -> str:
    while ',' in number:
        number = number.replace(',', '')
    return number


# Dado um valor de tempo no formato '{numero} {unidade_de_tempo}',
# Retorna um float que representa o mesmo valor em nanosegundos
def format_time_scale(value: str) -> float:
    time_units = {'ps': -3, 'ns': 0, 'μs': 3, 'ms': 6, 's': 9}

    numeric_value, time_scale = value.split(' ')
    number = float(format_number(numeric_value))
    exponent = time_units[time_scale]

    nanosecond = math.pow(10, exponent) * number
    return nanosecond


# Dado um valor de memória no formato '{numero} {unidade_de_memória}'
# Retorna um int que representa o mesmo valor em Bytes
def format_memory_scale(value: str) -> int:
    memory_units = {'B': 0, 'KB': 10, 'MB': 20}

    numeric_value, memory_scale = value.split(' ')
    number = float(format_number(numeric_value))
    exponent = memory_units[memory_scale]

    byte = int(math.pow(2, exponent) * number)
    return byte


# Remove o prefixo de uma String
def remove_prefix(value: str, prefix: str) -> str:
    return value[len(prefix):]


# Dado um DataFrame, ele é separado em 2 através dos sufixos da coluna 'Method'
def prepare_dataframe_to_comparison(df: pd.DataFrame, prefix1: str, prefix2: str) -> dict[str, pd.DataFrame]:
    df = df.sort_values(by='Method')
    data: dict[str, pd.DataFrame] = {
        prefix1: df.copy().iloc[:int(len(df) / 2), :],
        prefix2: df.copy().iloc[int(len(df) / 2):, :]
    }

    for prefix in [prefix1, prefix2]:
        data[prefix].loc[:, 'Method'] = data[prefix].loc[:, 'Method'].apply(lambda x: remove_prefix(x, prefix))
        data[prefix]['Mean'] = data[prefix]['Mean'].apply(format_time_scale)
        data[prefix]['Allocated'] = data[prefix]['Allocated'].apply(format_memory_scale)

    return data


# Ao receber um DataFrame, retorna um DataFrame relatório
# Sobre os dados do DataFrame provido (Method, ListSize, Mean, Allocated)
def compare_dataframe(df: pd.DataFrame, prefixes: list[str], prefix1: str, prefix2: str) -> pd.DataFrame:
    prefix = prepare_dataframe_to_comparison(df, prefix1, prefix2)

    data = {
        'Method': prefix[prefix1]['Method'].to_list(), 'ListSize': prefix[prefix1]['ListSize'].to_list(),
        f'Mean{prefix1}': prefix[prefix1]['Mean'].to_list(), f'Mean{prefix2}': prefix[prefix2]['Mean'].to_list(),
        'Mean X': np.array(prefix[prefix1]['Mean']) / np.array(prefix[prefix2]['Mean']),
        f'Allocated{prefix1}': prefix[prefix1]['Allocated'].to_list(),
        f'Allocated{prefix2}': prefix[prefix2]['Allocated'].to_list(),
        'Allocated X': np.array(prefix[prefix1]['Allocated']) / np.array(prefix[prefixes[1]]['Allocated'])
    }

    return pd.DataFrame(data)


# Agrupa os dados por uma coluna de um DataFrame e os mapeia para um dicionário
def group_by_column(df: pd.DataFrame, column_name: str) -> dict[str, pd.DataFrame]:
    group = {}
    unique_values = df[column_name].unique()
    for value in unique_values:
        group[value] = df[df[column_name] == value]
    return group


def main() -> None:
    path = get_logs_path('..', 'Console', r'bin\Release\net6.0\BenchmarkDotNet.Artifacts\results')
    csvs = get_directory_csvs(path)

    raw_data = csvs_to_dataframe_dictionary(path, csvs)
    data = format_dataframe_dictionary(raw_data, ['Method', 'ListSize', 'Mean', 'Error', 'StdDev', 'Rank', 'Allocated'])

    data_union = pd.concat(data.values())

    compared_data = compare_dataframe(data_union, ['FastList', 'NormalList'], 'FastList', 'NormalList')

    group = group_by_column(compared_data, 'ListSize')

    with pd.option_context('display.max_rows', None, 'display.max_columns', None, 'display.expand_frame_repr', False):
        for k, v in group.items():
            print(f'{k}:\n{v}')


if __name__ == '__main__':
    main()
