using Dropbox.Api;
using Dropbox.Api.Files;
using Dropbox.Api.Sharing;
using Sentry;

namespace APICore3._1.Util;

public static class DropboxHelper
{
    public static string TOKEN = "";

    public static async Task<string> UploadDropbox(FileStream fs, string fileName)
    {
        try
        {
            fileName = $"{Guid.NewGuid()}.{fileName.Split(".")[fileName.Split(".").Length - 1]}";

            var token =
                "sl.BG7_anAgmk4esjCf-ZBy2Q3DNrCVhB9iAtvLNZ7F30R8nf-rvv7q3ruR6rLWoVxqBVhJ3Arth6TVHJBp_kNhi4Fhz28bu_NeQ7ctD5ekQCQPhG01Q1laWPkxHHc3S2P-p-Js26jU";
            var folder = "HRMdev";
            var client = new DropboxClient(token, DateTime.Now.AddYears(3));
            var response =
                await client.Files.UploadAsync("/" + folder + "/" + fileName, WriteMode.Overwrite.Instance, body: fs);
            //create public share link
            var s = await client.Sharing.CreateSharedLinkWithSettingsAsync(
                new CreateSharedLinkWithSettingsArg(response.PathLower));
            return s.Url.Replace("dl=0", "raw=1");
        }
        catch (Exception ex)
        {
            SentrySdk.CaptureException(ex);
        }

        return "";
    }
}