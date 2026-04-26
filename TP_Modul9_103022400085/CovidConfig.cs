using System.Text.Json;

namespace TP_Modul9_103022400085;

public class CovidConfig
{
    public string satuan_suhu { get; set; }
    public int batas_hari_demam { get; set; }
    public string pesan_ditolak { get; set; }
    public string pesan_diterima { get; set; }

    public static void UbahSatuan()
    {
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
        
        if (covidConfig.satuan_suhu == "celcius") covidConfig.satuan_suhu = "fahrenheit";
        else if (covidConfig.satuan_suhu == "fahrenheit") covidConfig.satuan_suhu = "celcius";
        else covidConfig.satuan_suhu = "celcius";
        
        File.WriteAllText("covid_config.json", JsonSerializer.Serialize(covidConfig));
    }
}