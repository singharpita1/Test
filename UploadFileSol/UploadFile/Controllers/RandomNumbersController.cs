using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using UploadFile.Data;
using UploadFile.Models;
using Microsoft.AspNetCore.Http;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Diagnostics;

namespace UploadFile.Controllers
{
    public class RandomNumbersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RandomNumbersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RandomNumbers
        public async Task<IActionResult> Index()
        {
            return View(await _context.RandomNumbers.ToListAsync());
        }

        // GET: RandomNumbers/Create
        public IActionResult Create()
        {
            return View();
        }

        // GET: RandomNumbers/Mean
        public IActionResult Mean()
        {
            
            return View();
        }

        // Post: RandomNumber/MeanResult
        public async Task<IActionResult> MeanResult()
        {
            SqlConnection con;

            SqlDataAdapter da;

            int count = 0;
            double temp = 0.0;
            double mean = 0.0;
            DataSet ds = new DataSet();
            con = new SqlConnection("Data Source=(localdb)\\mssqllocaldb;Database=aspnet-UploadFile-ED3612D1-4879-47A8-A45C-793B74070C31");
            da = new SqlDataAdapter("select * from RandomNumbers", con);

            da.Fill(ds);

            foreach (DataRow dr in ds.Tables[0].Rows)

            {

                _context.Add(new RandomNumbers() { Id = int.Parse(dr[0].ToString()), A = dr[1].ToString() });
                temp += Convert.ToDouble(dr[1].ToString());
                count++;
            }

            mean = temp / count;
            ViewData.Model = mean.ToString();
            return View("Mean",mean.ToString());
        }

        // GET: RandomNumbers/StandardDeviation
        public IActionResult StandardDeviation()
        {

            return View();
        }

        // Post: RandomNumber/StandardDeviation
        public async Task<IActionResult> StandardDeviationResult()
        {
            SqlConnection con;
            SqlDataAdapter da;

            int count = 0;
            double temp = 0.0;
            double mean = 0.0;
            double standdeviation = 0.0;
            DataSet ds = new DataSet();
            con = new SqlConnection("Data Source=(localdb)\\mssqllocaldb;Database=aspnet-UploadFile-ED3612D1-4879-47A8-A45C-793B74070C31");
            da = new SqlDataAdapter("select * from RandomNumbers", con);

            da.Fill(ds);

            foreach (DataRow dr in ds.Tables[0].Rows)

            {

                _context.Add(new RandomNumbers() { Id = int.Parse(dr[0].ToString()), A = dr[1].ToString() });
                temp += Convert.ToDouble(dr[1].ToString());
                count++;
            }

            mean = temp / count;
            standdeviation = ((temp + mean) / count) * 0.5;
            double error = 0.00001; //define the precision of your result
            double low = 0;
            double high = standdeviation;
            double mid = 0;

            while (high - low > error)
            {
                mid = low + (high - low) / 2; // finding mid value
                if (mid * mid > standdeviation)
                {
                    high = mid;
                }
                else
                {
                    low = mid;
                }
            }
            ViewData.Model = mid.ToString();
            return View("StandardDeviation", mid.ToString());
        }

        // GET: RandomNumbers/Frequency
        public IActionResult Frequency()
        {

            return View();
        }

        // Post: RandomNumber/Frequency
        public IActionResult FrequencyResult(int flag)
        {
            SqlConnection con;
            SqlDataAdapter da;

            int count = 0;
            int count1 = 0;
            int count2 = 0, count3 = 0, count4 = 0, count5 = 0, count6 = 7, count7 = 8, count8 = 0, count9 = 0;
            double temp = 0.0;
            var numbers = new List<double> { };
            var range = new List<double> { };
            List<string> result = new List<string> { };
            DataSet ds = new DataSet();
            con = new SqlConnection("Data Source=(localdb)\\mssqllocaldb;Database=aspnet-UploadFile-ED3612D1-4879-47A8-A45C-793B74070C31");
            da = new SqlDataAdapter("select * from RandomNumbers", con);

            da.Fill(ds);

            foreach (DataRow dr in ds.Tables[0].Rows)

            {

                _context.Add(new RandomNumbers() { Id = int.Parse(dr[0].ToString()), A = dr[1].ToString() });
                temp = Convert.ToDouble(dr[1].ToString());
                numbers.Add(Convert.ToDouble(dr[1].ToString()));

            }

            foreach(var n in numbers)
            {
                if(n >= 0.0 && n< 10.0)
                {
                    count++;
                }

                if(n >= 10.0 && n < 20.0)
                {
                    count1++;
                }

                if (n >= 20.0 && n < 30.0)
                {
                    count2++;
                }

                if (n >= 30.0 && n < 40.0)
                {
                    count3++;
                }
                if (n >= 40.0 && n < 50.0)
                {
                    count4++;
                }
                if (n >= 50.0 && n < 60.0)
                {
                    count5++;
                }
                if (n >= 60.0 && n < 70.0)
                {
                    count6++;
                }
                if (n >= 70.0 && n < 80.0)
                {
                    count7++;
                }
                if (n >= 80.0 && n < 90.0)
                {
                    count8++;
                }
                if (n >= 90.0 && n < 100.0)
                {
                    count9++;
                }
            }
            result.Add(string.Format("Value={0}, Frequency={1}", "0.0 to 9.9", count));
            result.Add(string.Format("Value={0}, Frequency={1}", "10.0 to 19.9", count1));
            result.Add(string.Format("Value={0}, Frequency={1}", "20.0 to 29.9", count2 + "\n"));
            result.Add(string.Format("Value={0}, Frequency={1}", "30.0 to 39.9", count3 + "\n"));
            result.Add(string.Format("Value={0}, Frequency={1}", "40.0 to 49.9", count4 + "\n"));
            result.Add(string.Format("Value={0}, Frequency={1}", "50.0 to 59.9", count5 + "\n"));
            result.Add(string.Format("Value={0}, Frequency={1}", "60.0 to 69.9", count6 + "\n"));
            result.Add(string.Format("Value={0}, Frequency={1}", "70.0 to 79.9", count7 + "\n"));
            result.Add(string.Format("Value={0}, Frequency={1}", "80.0 to 89.9", count8 + "\n"));
            result.Add(string.Format("Value={0}, Frequency={1}", "90.0 to 99.9", count9 + "\n"));

            ViewData.Model = result;

            string items = string.Join(Environment.NewLine, result.ToArray());

            return View("Frequency",items );
        }
        [HttpPost]
        public async Task<IActionResult> Create(IFormFile file, [Bind("Id,A")] RandomNumbers randomNumbers)
        {
            if (file == null || file.Length == 0)
                return Content("file not selected");

            var path = Path.GetTempFileName();
           
            if (file.FileName.EndsWith(".csv"))
            {
                using (var sreader = new StreamReader(file.OpenReadStream()))
                {
                    string[] headers = sreader.ReadLine().Split(',');
                    int len = headers.Length;
                    var randomNumber1 = new RandomNumbers[1000];
                    for (int i = 0; i <= headers.Length - 1; i++)
                    {
                        randomNumber1[i] = new RandomNumbers {A = headers[i] };
                    }

                    foreach (RandomNumbers r in randomNumber1)
                    {
                        _context.RandomNumbers.Add(r);
                    }
                    _context.SaveChanges();
                }  
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
