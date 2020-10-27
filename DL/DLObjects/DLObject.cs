using BE.Entities;
using DL.DataBases;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v2.Data;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace DL.DLObjects
{
    public class DLObject : IDL
    {
        // If modifying these scopes, delete your previously saved credentials
        // at ~/.credentials/drive-dotnet-quickstart.json
        private static string[] Scopes = { DriveService.Scope.DriveReadonly };
        static string ApplicationName = "Drive API .NET Quickstart";
        DriveService _service;
        private Random _random = new Random();

        public DLObject()
        {
            //UpdateActiveIngredientsDBSync();
        }

        private async void UpdateActiveIngredientsDBSync()
        {
            await UpdateActiveIngredientsDB();
        }
        private async Task UpdateActiveIngredientsDB()
        {
            await Task.Run(() =>
            {

                XmlReader reader = XmlTextReader.Create("ActiveIngerdient/ActiveIngrdedientsDB.xml");
                List<ActiveIngredient> xmls = new List<ActiveIngredient>();
                int num = 0;
                while (!reader.EOF && num <= 30)
                {
                    if (reader.Name != "minConcept")
                    {
                        reader.ReadToFollowing("minConcept");
                    }
                    if (!reader.EOF)
                    {
                        XElement xml = (XElement)XElement.ReadFrom(reader);
                        ActiveIngredient item = new ActiveIngredient() { Name = (string)xml.Element("name"), Rxcui = (string)xml.Element("rxcui") };
                        try
                        {
                            AddActiveIngredient(item);
                            num++;
                        }
                        catch
                        {

                        }
                    }
                }
                //System.Xml.XmlDocument root = new System.Xml.XmlDocument();
                //root.Load("ActiveIngerdient/ActiveIngrdedientsDB.xml");
                //string content = root.InnerXml;

                //XmlNodeList nodes = root.DocumentElement.SelectNodes("/minConceptGroup/minConcept");
                //foreach (XmlNode node in nodes)
                //{
                //    String name = node.SelectSingleNode("name").InnerText;
                //    String rxcui = node.SelectSingleNode("rxcui").InnerText;
                //    AddActiveIngredient(new ActiveIngredient(name, rxcui));
                //}
            });
        }

        private void SetGoogleDrive()
        {
            UserCredential credential;

            using (var stream =
                new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
            {
                // The file token.json stores the user's access and refresh tokens, and is created
                // automatically when the authorization flow completes for the first time.
                string credPath = "token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);
            }

            // Create Drive API service.
            _service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            // Define parameters of request.
            FilesResource.ListRequest listRequest = _service.Files.List();
            listRequest.PageSize = 10;
            listRequest.Fields = "nextPageToken, files(id, name)";

            // List files.
            IList<Google.Apis.Drive.v3.Data.File> files = listRequest.Execute()
                .Files;
            Console.WriteLine("Files:");
            if (files != null && files.Count > 0)
            {
                foreach (var file in files)
                {
                    Console.WriteLine("{0} ({1})", file.Name, file.Id);
                }
            }
            else
            {
                Console.WriteLine("No files found.");
            }
            Console.Read();
        }

        public void AddAdmin(Admin admin)
        {
            using (var db = new DrConsoleDB())
            {
                db.AdminsDB.Add(admin);
                db.SaveChanges();
            }
        }

        public void AddDoctor(Doctor doctor)
        {
            using (var db = new DrConsoleDB())
            {
                db.DoctorsDB.Add(doctor);
                db.SaveChanges();
            }
        }

        public void AddDrug(Drug drug)
        {
            string newImagePath = @"..\..\Global\Images\DrugImages\" + drug.DrugName + RandomString() + @".jpg";
            (System.IO.File.Create(newImagePath)).Close();
            System.IO.File.Copy(drug.ImgSrc, newImagePath, true);

            drug.ImgSrc = newImagePath;
            using (var db = new DrConsoleDB())
            {
                db.DrugsDB.Add(drug);
                db.SaveChanges();
            }
        }

        public void AddPatient(Patient patient)
        {
            using (var db = new DrConsoleDB())
            {
                db.PatientsDB.Add(patient);
                db.SaveChanges();
            }
        }

        public void AddPrescription(Prescription prescription)
        {
            using (var db = new DrConsoleDB())
            {
                db.PrescriptionDB.Add(prescription);
                db.SaveChanges();
            }
        }

        public void AddActiveIngredient(ActiveIngredient active)
        {
            using (var db = new DrConsoleDB())
            {
                db.ActiveIngredientsDB.Add(active);
                db.SaveChanges();
            }
        }

        public void DeleteActiveIngredient(ActiveIngredient active)
        {
            using (var db = new DrConsoleDB())
            {
                db.Entry(active).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public void DeleteAdmin(Admin admin)
        {
            using (var db = new DrConsoleDB())
            {
                db.Entry(admin).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public void DeleteDoctor(Doctor doctor)
        {
            using (var db = new DrConsoleDB())
            {
                db.Entry(doctor).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public void DeleteDrug(Drug drug)
        {
            try
            {
                System.IO.File.Delete(drug.ImgSrc);
            }
            catch { }
            using (var db = new DrConsoleDB())
            {
                db.Entry(drug).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public void DeletePatient(Patient patient)
        {
            using (var db = new DrConsoleDB())
            {
                db.Entry(patient).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public List<Admin> GetAllAdmins()
        {
            using (var db = new DrConsoleDB())
            {
                return (from a in db.AdminsDB select a).ToList();
            }
        }

        public List<Doctor> GetAllDoctors()
        {
            using (var db = new DrConsoleDB())
            {
                return (from d in db.DoctorsDB select d).ToList();
            }
        }

        public List<Drug> GetAllDrugs()
        {
            using (var db = new DrConsoleDB())
            {
                return (from d in db.DrugsDB select d).ToList();
            }
        }

        public List<ActiveIngredient> GetAllActiveIngredients()
        {
            using(var db = new DrConsoleDB())
            {
                return (from a in db.ActiveIngredientsDB select a).ToList();
            }
        }
        public List<Patient> GetAllPatients()
        {
            using (var db = new DrConsoleDB())
            {
                return (from p in db.PatientsDB select p).ToList();
            }
        }

        public List<Prescription> GetAllPrescriptions()
        {
            using (var db = new DrConsoleDB())
            {
                return (from p in db.PrescriptionDB select p).ToList();
            }
        }

        public Doctor GetDoctor(string doctorId)
        {
            using (var db = new DrConsoleDB())
            {
                return (from d in db.DoctorsDB where d.ID.Equals(doctorId) select d).FirstOrDefault();
            }
        }

        public Drug GetDrug(string drugName)
        {
            using (var db = new DrConsoleDB())
            {
                return (from d in db.DrugsDB where d.DrugName.Equals(drugName) select d).FirstOrDefault();
            }
        }

        public Patient GetPatient(string patientId)
        {
            using (var db = new DrConsoleDB())
            {
                return (from p in db.PatientsDB where p.ID.Equals(patientId) select p).FirstOrDefault();
            }
        }

        public void UpdateAdmin(Admin a)
        {
            using (var db = new DrConsoleDB())
            {
                db.AdminsDB.AddOrUpdate(a);
                db.SaveChanges();
            }
        }

        public void UpdateDoctor(Doctor d)
        {
            using (var db = new DrConsoleDB())
            {
                db.DoctorsDB.AddOrUpdate(d);
                db.SaveChanges();
            }
        }

        public void UpdatePatient(Patient p)
        {
            using (var db = new DrConsoleDB())
            {
                db.PatientsDB.AddOrUpdate(p);
                db.SaveChanges();
            }
        }

        public void UpdateDrug(Drug d)
        {
            using (var db = new DrConsoleDB())
            {
                db.DrugsDB.AddOrUpdate(d);
                db.SaveChanges();
            }
        }

        private string RandomString()
        {
            var builder = new StringBuilder(12);

            // Unicode/ASCII Letters are divided into two blocks
            // (Letters 65–90 / 97–122):
            // The first group containing the uppercase letters and
            // the second group containing the lowercase.  

            // char is a single Unicode character  
            char offset = 'A';
            const int lettersOffset = 26; // A...Z or a..z: length=26  

            for (var i = 0; i < 12; i++)
            {
                var @char = (char)_random.Next(offset, offset + lettersOffset);
                builder.Append(@char);
            }

            return builder.ToString();
        }
    }
}
