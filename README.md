# CodeSmells

A set of code smells used for experimenting with energy consumption.

## Using CodeQL

More info, including CodeQL setup, at [cs-22-pt-10-02/energy-queries (TBA)]()

---

To analyze this project simply run `codeql.sh`. This script will:

- delete the previous source code database if present
    - it may be possible to simply update the database rather than deleting and recreating - however unsure
- create a new source code database necessary for analysis
- perform the analysis using [cs-22-pt-10-02/energy-queries (TBA)]()
- results will be printed in `res.csv`
