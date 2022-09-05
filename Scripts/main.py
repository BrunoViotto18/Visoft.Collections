import pandas as pd
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
        if '.csv' == file[len(file)-4:]:
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

    numeric_value = value[:len(value) - 3]
    time_scale = value[len(value) - 3:].strip()
    exponent = time_units[time_scale]

    number = float(format_number(numeric_value))
    nanoseconds = math.pow(10, exponent) * number

    return nanoseconds


# Função de mapa para a criação de uma coluna em um DataFrame
def add_formatted_time_scale_column(df: pd.DataFrame) -> pd.DataFrame:
    return df['Mean'].apply(format_time_scale)


# Agrupa os dados por uma coluna de um DataFrame e os mapeia para um dicionário
def group_by_argument(d: pd.DataFrame, column_name: str) -> dict[str, pd.DataFrame]:
    group = {}
    unique_values = d[column_name].unique()
    for value in unique_values:
        group[value] = d[d[column_name] == value]
    return group


# Remove um prefixo de uma String
def remove_comparison_prefix(value: str, prefix: str) -> str:
    return value[len(prefix):]


def compare_dataframe(df: pd.DataFrame, column_name: str, prefixes: list[str]) -> dict[str, pd.DataFrame]:
    prefix: dict[str, pd.DataFrame] = {}
    df = df.sort_values(by=column_name)

    for p in range(len(prefixes)):
        prefix[prefixes[p]] = df.iloc[int(p * len(df) / len(prefixes)):int((p+1) * len(df) / len(prefixes)), :]
        prefix[prefixes[p]][column_name] = prefix[prefixes[p]][column_name]\
            .apply(lambda x: remove_comparison_prefix(x, prefixes[p]))

    print(prefix[prefixes[0]])
    d = {'Method': [], 'ListSize': [], f'Mean {prefixes[0]}': [], f'Mean {prefixes[1]}': [], 'Mean %': [], 'Error %': [], 'StdDev %': [], f'Allocated {prefixes[0]}': [], f'Allocated {prefixes[1]}': [], 'Allocated %': []}
    for i in range(len(prefix[prefixes[0]])):
        d['Method'].append(prefix[prefixes[0]].loc[i, 'Method'])
    
    print(d)


def main() -> None:
    path = get_logs_path('..', 'Console', r'bin\Release\net6.0\BenchmarkDotNet.Artifacts\results')
    csvs = get_directory_csvs(path)

    raw_data = csvs_to_dataframe_dictionary(path, csvs)
    data = format_dataframe_dictionary(raw_data, ['Method', 'ListSize', 'Mean', 'Error', 'StdDev', 'Rank', 'Allocated'])

    all_data = pd.concat(data.values())
    all_data = all_data.assign(Mean_ns=add_formatted_time_scale_column).sort_values(by='Mean_ns', ascending=False)

    group = compare_dataframe(all_data, 'Method', ['FastList', 'NormalList'])

    for k, v in group.items():
        print(f'\n{k}:\n{v}\n')


if __name__ == '__main__':
    main()
