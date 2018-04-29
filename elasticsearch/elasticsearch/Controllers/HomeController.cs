using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using elasticsearch.Models;
using Nest;
using System.Data;
using System.Dynamic;

namespace elasticsearch.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var node = new Uri("http://localhost:9200");
            var settings = new ConnectionSettings(node);
            var client = new ElasticClient(settings);



            var table = new DataTable();

            table.Columns.Add("Dosage", typeof(int));
            table.Columns.Add("Drug", typeof(string));
            table.Columns.Add("Patient", typeof(string));
            table.Columns.Add("Date", typeof(DateTime));

            // Here we add five DataRows.
            table.Rows.Add(25, "Indocin", "David", DateTime.Now);
            table.Rows.Add(50, "Enebrel", "Sam", DateTime.Now);
            table.Rows.Add(10, "Hydralazine", "Christoff", DateTime.Now);
            table.Rows.Add(21, "Combivent", "Janet", DateTime.Now);
            table.Rows.Add(100, "Dilantin", "Melanie", DateTime.Now);


            var dicty = new skrtt();

            foreach (DataRow row in table.Rows)
            {
                foreach (DataColumn column in table.Columns)
                {
                    var asdf = column.ToString();
                    dicty.GetType().GetProperty(asdf).SetValue(dicty, row[column]);
                }
                var response = client.Index(dicty, idx => idx.Index("456456456")); //or specify index via settings.DefaultIndex("mytweetindex");
                dicty = new skrtt();

                var safd = 123;
            }

            dynamic expando = new ExpandoObject();
            expando.Name = "Brian";
            expando.Country = "USA";
            AddProperty(expando, "Language", "English");


            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
