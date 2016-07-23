namespace TestJsAngDotNet.App_Start
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using Models;
    using System;

    public class DataBaseInitializer : DropCreateDatabaseAlways<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            try
            {
                var listData = new List<ListData>();
                for (var i = 0; i < 1000; i++)
                {
                    listData.Add(new ListData
                    {
                        Name = string.Format("DataRow Number {0}", i)
                    });
                }
                for (var i = 1000; i < 2000; i++)
                {
                    listData.Add(new ListData
                    {
                        Name = string.Format("Test Substr Search {0}", i)
                    });
                }

                listData.ForEach(s => context.ListDatas.Add(s));
                context.SaveChanges();

                listData.ForEach(s => context.DataInfos.Add(new DataInfo
                {
                    //Id = i,
                    Text1 = string.Format("First Text Of Number {0}", s.Id-1),
                    Text2 = string.Format("Second Text Of Number {0}", s.Id - 1),
                    IntField1 = (int)(s.Id - 1),
                    ListDataId = s.Id
                }));

                context.SaveChanges();
            }
            catch (Exception ex) {
                throw ex;
            }
        }
    }
}