using SalesDepartament_2;

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

    new Company() { Name = "Sberbank", Details = "Bank", ManagerName = "Oleg", Contract = 5000 },
    new Company() { Name = "Gazprom", Details = "dfsg", ManagerName = "Oleg", Contract = 6000 },
    new Company() { Name = "Nornickel", Details = "afsdf", ManagerName = "Oleg", Contract = 7000 },

    new Company() { Name = "Greenagro", Details = "Food", ManagerName = "Anton", Contract = 500 },
};

//var report_join_company_text = from company in companies
//                               join manager in managers on company.ManagerName equals manager.FullName
//                               select $"{company.Name} - {manager.FullName}";

//var report_join_manager_text = from manager in managers
//                               join company in companies on manager.FullName equals company.ManagerName
//                               select $"{company.Name} - {manager.FullName}";

//var report_join_manager_text2 = from manager in managers
//                                join company in companies on manager.FullName equals company.ManagerName
//                                select $"{manager.FullName} - {company.Name}";


//var report_join_company_collection = from company in companies
//                                     join manager in managers on company.ManagerName equals manager.FullName into managerCollection
//                                     select new
//                                     {
//                                         Company = company.Name,
//                                         Managers = managerCollection
//                                     };
//report_join_company_collection.ToList();

//var report_join_manager_collection = from manager in managers
//                                     join company in companies on manager.FullName equals company.ManagerName into companyCollection
//                                     select new
//                                     {
//                                         Manager = manager.FullName,
//                                         Companies = companyCollection
//                                     };
//report_join_manager_collection.ToList();


var report1 = (from manager in managers
               join company in companies on manager.FullName equals company.ManagerName into companyCollection
               select new
               {
                   Manager = manager,
                   Companies = companyCollection.Select(x => x),
                   ContractCount = companyCollection.Count(),
                   ContractSum = companyCollection.Sum(x => x.Contract)
               }).OrderByDescending(x => x.ContractSum);



var report2 = managers.GroupJoin(companies,
    manager => manager.FullName,
    company => company.ManagerName,
    (manager, companyCollection) => new
    {
        Manager = manager,
        Companies = companyCollection.Select(x => x),
        ContractCount = companyCollection.Count(),
        ContractSum = companyCollection.Sum(x => x.Contract)
    }).OrderByDescending(x => x.ContractSum);


//var report_left_join_0 = (from manager in managers
//                          join company in companies on manager.FullName equals company.ManagerName into companyCollection
//                          from companyItem in companyCollection
//                          select new
//                          {
//                              Manager = manager,
//                              Companies = companyCollection,
//                              ContractCount = companyCollection.Count(),
//                              ContractSum = companyCollection.Sum(x => x.Contract)
//                          }).OrderByDescending(x => x.ContractSum);
//report_left_join_0.ToList();

//var report_left_join_1 = (from manager in managers
//                          join company in companies on manager.FullName equals company.ManagerName into companyCollection
//                          from companyItem in companyCollection.DefaultIfEmpty()
//                          select new
//                          {
//                              Manager = manager,
//                              Companies = companyCollection,
//                              ContractCount = companyCollection.Count(),
//                              ContractSum = companyCollection.Sum(x => x.Contract)
//                          }).OrderByDescending(x => x.ContractSum);
//report_left_join_1.ToList();


var report3 = (from manager in managers
               join company in companies on manager.FullName equals company.ManagerName into companyCollection
               //where companyCollection.Count() > 0
               let companyCount = companyCollection.Count()
               where companyCount > 0
               select new
               {
                   Manager = manager,
                   Companies = companyCollection.Select(x => x),
                   ContractCount = companyCount,
                   ContractSum = companyCollection.Sum(x => x.Contract)
               }).OrderByDescending(x => x.ContractSum);


Console.WriteLine();
Console.WriteLine();