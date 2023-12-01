using SalesDepartament_1;

Manager[] managers =
{
    new Manager() { FullName = "Ivan", Position = "Старший", Level = "123" },
    new Manager() { FullName = "Anton", Position = "Обычный", Level = "234" },
    new Manager() { FullName = "Oleg", Position = "Младший", Level = "45" },
    new Manager() { FullName = "Elena", Position = "Старший", Level = "56" },
};

Company[] companies =
{
    new Company() { Name = "Telegram", Details = "IT", ManagerName = "Ivan", Contract = 3000 },
    new Company() { Name = "Yandex", Details = "IT", ManagerName = "Ivan", Contract = 1000 },

    new Company() { Name = "Ozon", Details = "IT", ManagerName = "Anton", Contract = 4000 },
    new Company() { Name = "Vk", Details = "IT", ManagerName = "Anton", Contract = 2000 },
    new Company() { Name = "Greenagro", Details = "Food", ManagerName = "Anton", Contract = 500 },

    new Company() { Name = "Sberbank", Details = "Bank", ManagerName = "Oleg", Contract = 5000 },
    new Company() { Name = "Gazprom", Details = "dfsg", ManagerName = "Oleg", Contract = 6000 },
    new Company() { Name = "Nornickel", Details = "afsdf", ManagerName = "Oleg", Contract = 7000 },
};

IEnumerable<IGrouping<string, Company>> groupCompanies = from company in companies
                                                         group company by company.ManagerName;

var report1 = (from company in companies
               group company by company.ManagerName into companiesByManagerName
               select new
               {
                   Manager = managers.Single(x => x.FullName == companiesByManagerName.Key),
                   ContractCount = companiesByManagerName.Count(),
                   ContractSum = companiesByManagerName.Sum(x => x.Contract),
                   Companies = companiesByManagerName.Select(x => x)
               }).OrderByDescending(x => x.ContractSum);

Console.WriteLine();
Console.WriteLine();