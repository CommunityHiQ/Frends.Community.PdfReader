# Frends.Community.PdfReader
Frends task for reading PDF documents. Will not work on all PDF files.

- [Installing](#installing)
- [Tasks](#tasks)
  - [ReadPdf](#readepdf)
- [License](#license)
- [Building](#building)
- [Contributing](#contributing)
- [Change Log](#change-log)

# Installing
You can install the task via FRENDS UI Task View or you can find the nuget package from the following nuget feed
'Nuget feed coming at later date'

Tasks
=====

## ReadPdf

### Task Properties

### Options

Settings for reading the PDF file.

| Property             | Type                 | Description                          | Example |
| ---------------------| ---------------------| ------------------------------------ | ----- |
| ReadFromFile | bool | Read PDF from a file. | true |
| PdfLocation | string | Location of the PDF file. | C:\Pdf_Output\my_pdf_file.pdf |
| InputBytes | byte[] | PDF bytes | |
| Page		  | int	   | Specify which page to read. 0 read every page  | 1 |



### Result
| Property             | Type                 | Description                          | Example |
| ---------------------| ---------------------| ------------------------------------ | ----- |
| Content | string | PDF content | "This is a test pdf. It contains all the info. " |


# License

This project is licensed under the MIT License - see the LICENSE file for details

# Building

Clone a copy of the repo

`git clone https://github.com/CommunityHiQ/Frends.Community.PdfReader.git`

Restore dependencies

`nuget restore frends.community.pdfReader`

Rebuild the project

Run Tests with nunit3. Tests can be found under

`Frends.Community.PdfReader.Tests\bin\Release\Frends.Community.PdfReader.Tests.dll`

Create a nuget package

`nuget pack nuspec/Frends.Community.PdfReader.nuspec`

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
