# DVLD - Driving License Management System

A desktop application for managing the full driving license lifecycle —
applications, testing, issuance, renewal, and detention — built as part
of Course 19 in the Programming Advices roadmap by Dr. Mohammed Abu-Hadhoud.

## Status

🚧 Work in Progress — solution structure and database design in place,
core logic under active development.

## Tech Stack

- C# / .NET Framework
- Windows Forms
- ADO.NET
- SQL Server

## Architecture

3-tier architecture:

Presentation Layer (WinForms)
↓
Business Layer
↓
Data Access Layer (ADO.NET)
↓
SQL Server Database

## Project Structure
DVLD/
├── src/
│   ├── DVLD.PresentationLayer.WinForms/
│   ├── DVLD.BusinessLayer/
│   └── DVLD.DataAccessLayer/
├── database-scripts/
└── docs/



## Acknowledgment

Built as part of my learning journey with
[Programming Advices](https://programmingadvices.com),
under the guidance of Dr. Mohammed Abu-Hadhoud.