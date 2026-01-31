# ASCII Art Generator (C#)

A C# console application that converts a given string into a large ASCII-art representation using predefined banner templates.

---

## Features

* Converts text into ASCII-art banners
* Supports:

  * Letters (A–Z, a–z)
  * Numbers (0–9)
  * Spaces
  * Special characters
  * Newlines (`\n`)
* Multiple banner styles:

  * `standard`
  * `shadow`
  * `thinkertoy`
* Handles multiline input correctly
* Uses only standard .NET libraries

---

## Project Structure

```
ascii-art-dotnet/
│
├── BannerFiles/
│   ├── standard.txt
│   ├── shadow.txt
│   └── thinkertoy.txt
│
├── Program.cs
└── README.md
```

---

## Banner Format Rules

* Each character is represented by **8 lines**
* Characters are separated by a newline in the banner files
* ASCII characters range from **space (32)** to **tilde (126)**
* Banner files are read sequentially and mapped character-by-character

---

## How to Run

### i) Build & Run

```bash
dotnet run
```

### ii) Provide Input

You will be prompted for:

1. The string to convert
2. The banner style

Example interaction:

```
Enter your string : Hello There
1 - Standard
2 - Shadow
3 - thinkertoy
Press Enter to skip
Pick a banner style option (1 - 3) :
```

---

## Example Outputs

### Input

```
Hello
```

### Output (standard banner)

```
 _    _          _   _
| |  | |        | | | |
| |__| |   ___  | | | |   ___
|  __  |  / _ \ | | | |  / _ \
| |  | | |  __/ | | | | | (_) |
|_|  |_|  \___| |_| |_|  \___/
```

---

### Multiline Input

```
Hello
There
```

Produces:

```
 _    _          _   _
| |  | |        | | | |
| |__| |   ___  | | | |   ___
|  __  |  / _ \ | | | |  / _ \
| |  | | |  __/ | | | | | (_) |
|_|  |_|  \___| |_| |_|  \___/


 _______   _
|__   __| | |
   | |    | |__     ___   _ __    ___
   | |    |  _ \   / _ \ | '__|  / _ \
   | |    | | | | |  __/ | |    |  __/
   |_|    |_| |_|  \___| |_|     \___|
```

---

## Implementation Overview

### Banner Parsing

* Reads banner files line-by-line
* Maps each ASCII character (`char`) to a list of **8 strings**
* Stores mappings in a `Dictionary<char, List<string>>`

### Newline Handling

* Input is split on `\n`
* Empty lines produce blank ASCII output
* Each line is rendered independently

### ASCII Rendering

* For each line of text:

  * Loops 8 times (height of characters)
  * Concatenates matching banner rows horizontally
  * Prints the final ASCII art line by line

---

## Key Methods

* `SplitStringByNewLine(string input)`

  * Splits input while preserving `\n`
* `PrintLineAscii(string input, Dictionary<char, List<string>> bannerDict)`

  * Renders one line of ASCII art
* `PrintBannerMap(...)`

  * Debug helper to inspect loaded banners

---

## Notes & Limitations

* Characters outside ASCII range **32–126** are ignored
* Banner files must strictly follow the 8-line format
* No external packages are used

