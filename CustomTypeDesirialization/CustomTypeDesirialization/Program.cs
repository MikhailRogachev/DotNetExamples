
using CustomTypeDesirialization.Models;
using CustomTypeDesirialization.Services;

var service = new SettingsService();
var dbSettingsS = service.GetSetting<IList<string>>("DbSettings");

foreach(var setting in dbSettingsS)
    Console.WriteLine(setting);

Console.WriteLine("-------------------------------------------------------------");

var dbSettingsC = service.GetSetting<IList<VendorGroup>>("DbSettings");
foreach (var setting in dbSettingsC)
    Console.WriteLine(setting.ToString());

Console.ReadKey();