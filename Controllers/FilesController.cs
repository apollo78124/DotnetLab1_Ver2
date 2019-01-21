using System;
using System.IO;
using System.Collections;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using lab1.Models;
using System.Text;

namespace lab1.Controllers
{
    public class FilesController : Controller
    {
        public IActionResult Index()
        {
            //Assuming Test is your Folder
            string[] fileName = Directory.GetFiles("./wwwroot/TextFiles/"); //Getting Text files
           // var fileList
           //     = from p in fileNames
            //      select p;
            string[] files = new string[fileName.Length];
           for(var i = 0 ; i < files.Length; i++){
               files[i] = fileName[i].Split("./wwwroot/TextFiles/")[1].Split(".txt")[0];
           }
            ViewData.Model = files;

            return View();
        }

        public IActionResult Contents(string id)
        {   
            string path = "./wwwroot/TextFiles/" + id + ".txt";
            var lines = System.IO.File.ReadAllLines(path);
            Console.Write(lines);
            return View(lines);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
