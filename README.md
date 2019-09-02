# Regrep

A Find/Grep replacement with multiple levels of RegExp. Useful for filtering CSVFiles, JSONL or Logfiles.

Syntax: Regrep INFILE "RegularExpression (-"NOTRegularExpression" "RegularExpression" -"NOTRegularExpression")

**Examples:**

Find A but not B then filter result with C, but remove D (etc):

  *regrep INFILE "A" -"B" "C" -"D"*    (or *"A|C" -"B|D"*)

Find Swedish Phonenumbers from a mass of text:

  *regrep INFILE "[0-9 ]{2,5}[-]{1}[0-9 ]{5,9}"*
