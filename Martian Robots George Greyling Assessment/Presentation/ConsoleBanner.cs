namespace Martian_Robots_George_Greyling_Assessment.Presentation;

internal static class ConsoleBanner
{
    private const string Orange = "\u001b[38;2;255;140;0m";
    private const string ResetColour = "\u001b[0m";

    // Planet artwork by JT, from Christopher Johnson's ASCII Art Collection:
    // https://old.asciiart.website/index.php?art=nature/astronomy
    private const string BannerArt = """
                    o               .        ___---___                    .
                           .              .--\        --.     .     .         .
                                        ./.;_.\     __/~ \.
                                       /;  / `-'  __\    . \
                     .        .       / ,--'     / .   .;   \        |
                                     | .|       /       __   |      -O-       .
                                    |__/    __ |  . ;   \ | . |      |
                                    |      /  \\_    . ;| \___|
                       .    o       |      \  .~\\___,--'     |           .
                                     |     | . ; ~~~~\_    __|
                        |             \    \   .  .  ; \  /_/   .
                       -O-        .    \   /         . |  ~/                  .
                        |    .          ~\ \   .      /  /~          o
                      .                   ~--___ ; ___--~
                                     .          ---         .              -JT


                 __  __            _   _               ____       _           _
                |  \/  | __ _ _ __| |_(_) __ _ _ __  |  _ \ ___ | |__   ___ | |_ ___
                | |\/| |/ _` | '__| __| |/ _` | '_ \ | |_) / _ \| '_ \ / _ \| __/ __|
                | |  | | (_| | |  | |_| | (_| | | | ||  _ < (_) | |_) | (_) | |_\__ \
                |_|  |_|\__,_|_|   \__|_|\__,_|_| |_||_| \_\___/|_.__/ \___/ \__|___/
                """;

    public static void Show()
    {
        if (Console.IsOutputRedirected)
        {
            Console.WriteLine(BannerArt);
            return;
        }

        BeginOrangeText();
        Console.WriteLine(BannerArt);
    }

    public static void BeginOrangeText()
    {
        if (Console.IsOutputRedirected)
        {
            return;
        }

        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.Write(Orange);
    }

    public static void ResetTextColour()
    {
        if (Console.IsOutputRedirected)
        {
            return;
        }

        Console.Write(ResetColour);
        Console.ResetColor();
    }
}
