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

## PdfReaderTask.ReadPdf

Read the text content of a pdf-file. OBS! Doesn't do OCR. 

### Properties

| Property | Type | Description | Example |
| -------- | -------- | -------- | -------- |
| Options | Options(see below) |  |  |

### Options

| Property | Type | Description | Example |
| -------- | -------- | -------- | -------- |
| ReadFromFile | `bool` | Read the pdf-content from file | `true` |
| PdfLocation | `string` | Location of the pdf-file (if ReadFromFile==true)  | `c:\temp\mypdffile.pdf ` |
| InputBytes | `byte[]` | pdf-content as an byte array (if ReadFromFile==false)  |  |
| Page | int | Read only a certain page, 0 reads all the pages   | 0 |
### Returns

A result object with parameters.

| Property | Type | Description | Example |
| -------- | -------- | -------- | -------- |
| Content | `string` | Textual content of the Pdf-document | `This is a test pdf` |

Usage:
To fetch result use syntax:

`#result`

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

| Version | Changes |
| ------- | ------- |
| 0.0.1   | Development stil going on. |
| 0.0.2   | Fixed Readme.md  |