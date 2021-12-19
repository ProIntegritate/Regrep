# Regrep

A Find/Grep replacement with multiple levels of RegExp. Useful for filtering CSVFiles, JSONL or Logfiles.

Syntax: Regrep INFILE "RegularExpression (-"NOTRegularExpression" "RegularExpression" -"NOTRegularExpression")

**Examples:**

Find A but not B then filter result with C, but remove D (etc):

  *regrep INFILE "A" -"B" "C" -"D"*    (or *"A|C" -"B|D"*)

Find Swedish Phonenumbers from a mass of text:

  *regrep INFILE "[0-9 ]{2,5}[-]{1}[0-9 ]{5,9}"*

**Linux Port**

2021-12-19: An x64 Linux port is now available (Regrep.Linux.x64.Net50.gz), tested with Ubuntu 20.04.3 LTS.

The linux port requires .NET 5.0, which can be downloaded here:
 https://dotnet.microsoft.com/en-us/download/dotnet/5.0
If you are lazy, click here:
 https://github.com/ProIntegritate/Testing/blob/main/install_dotnet50.sh
