public class DailyInput
{
    private string SecretCookie { get; }

    public DailyInput(string secretCokkie)
    {
        this.SecretCookie = secretCokkie;
    }

    public async Task<string> GetInputForDay(int day)
    {
        if (File.Exists($"./input-{day}.txt"))
        {
            return await File.ReadAllTextAsync($"./input-{day}.txt");
        }
        else
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Cookie", $"session={this.SecretCookie}");
            var response = await client.GetAsync($"https://adventofcode.com/2023/day/{day}/input");

            var input = await response.Content.ReadAsStringAsync();
            await File.WriteAllTextAsync($"./input-{day}.txt", input);
            return input;
        }
    }
}