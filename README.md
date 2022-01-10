# Frends.Community.PdfReader

FRENDS Community Task for PdfReaderTask

[![Actions Status](https://github.com/CommunityHiQ/Frends.Community.PdfReader/workflows/PackAndPushAfterMerge/badge.svg)](https://github.com/CommunityHiQ/Frends.Community.PdfReader/actions) ![MyGet](https://img.shields.io/myget/frends-community/v/Frends.Community.PdfReader) [![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT) 

- [Installing](#installing)
- [Tasks](#tasks)
     - [PdfReaderTask](#PdfReaderTask)
- [Building](#building)
- [Contributing](#contributing)
- [Change Log](#change-log)

# Installing

You can install the task via FRENDS UI Task View or you can find the NuGet package from the following NuGet feed
https://www.myget.org/F/frends-community/api/v3/index.json and in Gallery view in MyGet https://www.myget.org/feed/frends-community/package/nuget/Frends.Community.PdfReader

# Tasks

## ReadPdf

Read the text content of a pdf-file. OBS! Doesn't do OCR. If pdf-file contains Forms, flatten them and read the form fields aswell. 

### Properties

| Property | Type | Description | Example |
| -------- | -------- | -------- | -------- |
| Options | Options(see below) |  |  |

### Options

Settings for reading the PDF file.

| Property             | Type                 | Description                          | Example |
| ---------------------| ---------------------| ------------------------------------ | ----- |
| ReadFromFile | bool | Read PDF from a file. | true |
| PdfLocation | string | Location of the PDF file. | C:\Pdf_Output\my_pdf_file.pdf |
| InputBytes | byte[] | PDF bytes | |
| Page		  | int	   | Specify which page to read. 0 read every page  | 1 |


### Returns

A result object with parameters.

| Property             | Type                 | Description                          | Example |
| ---------------------| ---------------------| ------------------------------------ | ----- |
| Content | string | PDF content | "This is a test pdf. It contains all the info. " |

Usage:
To fetch result use syntax:

`#result.Content`

# Building

Clone a copy of the repo

`git clone https://github.com/CommunityHiQ/Frends.Community.PdfReader.git`

Rebuild the project

`dotnet build`

Run Tests

`dotnet test`

Create a NuGet package

`dotnet pack --configuration Release`

# Contributing
When contributing to this repository, please first discuss the change you wish to make via issue, email, or any other method with the owners of this repository before making a change.

1. Fork the repo on GitHub
2. Clone the project to your own machine
3. Commit changes to your own branch
4. Push your work back up to your fork
5. Submit a Pull request so that we can review your changes

NOTE: Be sure to merge the latest from "upstream" before making a pull request!

# Change Log


| Version             | Changes                 |
| ---------------------| ---------------------|
| 0.0.3 | Initial version of PdfReader |
| 0.0.4 | Suport for acro fields |
| 0.0.7 | Multi-framework support , using iText7|
