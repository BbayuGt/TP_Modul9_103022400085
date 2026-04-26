// See https://aka.ms/new-console-template for more information

using System.Text.Json;
using TP_Modul9_103022400085;

// kasus jika file tidak ada
try
{
    File.ReadAllText("covid_config.json");
}
catch (FileNotFoundException)
{
    CovidConfig c =  new CovidConfig();
    c.satuan_suhu = "celcius";
    c.batas_hari_demam = 14;
    c.pesan_ditolak = "Anda tidak diperbolehkan masuk kedalam gedung ini";
    c.pesan_diterima = "Anda dipersilahkan untuk masuk ke dalam gedung ini";
    
    File.WriteAllText("covid_config.json", JsonSerializer.Serialize(c));
}

String file = File.ReadAllText("covid_config.json");
CovidConfig covidConfig =  JsonSerializer.Deserialize<CovidConfig>(file);

Console.Write($"Berapa suhu badan anda saat ini? Dalam nilai {covidConfig.satuan_suhu} : ");
float suhu =  float.Parse(Console.ReadLine());

Console.Write($"Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala demam?");
int days =  int.Parse(Console.ReadLine());

bool rejected = false;

// Bagian cek suhu
if (covidConfig.satuan_suhu == "celcius" && !(suhu > 36.5 && suhu < 37.5)) rejected = true;
else if (covidConfig.satuan_suhu == "fahrenheit" && !(suhu > 97.7 && suhu < 99.5)) rejected = true;

// Bagian hari demam
if (!(days < covidConfig.batas_hari_demam))  rejected = true;

if (rejected) Console.WriteLine(covidConfig.pesan_ditolak);
else Console.WriteLine(covidConfig.pesan_diterima);

// ubah satuan
CovidConfig.UbahSatuan();