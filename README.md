# SE 1 Student Tracker App for Group 8
## Adam Hooven, Adam Taylor, Braeden Mullins, Kyle Mazely, Nolan Trent

## Student Tracker App
The Student Tracker App is a Blazor web server application connected to a SQLite3 database, designed to help nursing students/teachers manage off-campus clinical visits, by providing geolocation information in combination with a check in/out process that supports appending comments. The app also supports intra-app messaging between users, as well as teachers post notifications to all students. The project focuses on simplicity, clarity, and real time information so that students can easily log their activity and teachers can monitor progress and provide timely updates.

---

## Project Vision

The vision of the Student Tracker App is to create a reliable and accessible platform that supports both student self-management and teacher oversight. Students can check in and out of clinical visits while the system records session location data. Teachers can view student check in/out logs, current location (only while checked in), message students, and post notifications when necessary.

The system aims to remain intuitive and easy to navigate for users of all technical comfort levels. The long term direction includes expanded analytics, stronger communication tools, smoother integration of progress tracking, and adding accessibility features to ensure users who need larger text or clearer layouts can navigate the app with ease.

---

## Core Features

### Student Features

* Check in and check out of clinical visits
* Automatic location validation during clinical visits
* Receive notifications from teachers
* Send and receive direct messages with teachers and other students

### Teacher Features

* View lists of students
* View checked in student locations
* Send site wide notifications 
* Send direct messages to individual students and other teachers

---

## System Scope

### In Scope

* Student profiles and clinical visit data
* Teacher profiles 
* Student and teacher messaging
* Role based access for students and teachers

### Out of Scope

* Mobile application(s)
* Integration with external learning or student information systems
* Automated notification delivery through SMS or email

---

## Technical Stack

* **Frontend**: Blazor WebAssembly
* **Backend**: ASP.NET Core or Node based services depending on configuration
* **Database**: SQLite
* **Hosting**: Self-Hosted
* **Version Control**: GitHub
* **Testing Tools**: GitHub Actions + MSTest

---

## Repository Structure

```
StudentTracker
├── LICENSE
├── README.md
├── StudentTracker.E2ETests
│   ├── StudentTracker.E2ETests.csproj
│   └── Tests
│       ├── AccountCreationTest.cs
│       ├── LoginTests.cs
│       ├── StudentCheckInTests.cs
│       └── TestBase.cs
├── StudentTrackerApp
│   ├── appsettings.Development.json
│   ├── appsettings.json
│   ├── Components
│   │   ├── _Imports.razor
│   │   ├── App.razor
│   │   ├── Layout
│   │   │   ├── MainLayout.razor
│   │   │   └── NavMenu.razor
│   │   ├── Pages
│   │   │   ├── CreateAccount.razor
│   │   │   ├── Dashboard.razor
│   │   │   ├── Error.razor
│   │   │   ├── Home.razor
│   │   │   ├── Locationtest.razor
│   │   │   ├── Messages.razor
│   │   │   ├── StudentCheckInLog.razor
│   │   │   ├── Teacher.razor
│   │   │   └── UserMessages.razor
│   │   └── Routes.razor
│   ├── Data
│   │   └── StudentTracker.db
│   ├── Migrations
│   │   ├── 20251020185419_AddDatabase.cs
│   │   ├── 20251020185419_AddDatabase.Designer.cs
│   │   ├── 20251020185515_StudentTeacherSeed.cs
│   │   ├── 20251020185515_StudentTeacherSeed.Designer.cs
│   │   ├── 20251022182940_CreationUserField.cs
│   │   ├── 20251022182940_CreationUserField.Designer.cs
│   │   ├── 20251027184437_MessagesMigration.cs
│   │   ├── 20251027184437_MessagesMigration.Designer.cs
│   │   ├── 20251103190711_AddCheckInLog.cs
│   │   ├── 20251103190711_AddCheckInLog.Designer.cs
│   │   ├── 20251117193145_Notes.cs
│   │   ├── 20251117193145_Notes.Designer.cs
│   │   └── ApplicationDbContextModelSnapshot.cs
│   ├── Models
│   │   ├── CheckInLog.cs
│   │   ├── Message.cs
│   │   ├── Student.cs
│   │   ├── StudentTeacher.cs
│   │   └── User.cs
│   ├── Program.cs
│   ├── Properties
│   │   └── launchSettings.json
│   ├── Repositories
│   │   ├── DbCheckInRepository.cs
│   │   ├── DbMessageRepository.cs
│   │   ├── DbStudentTeacherRepository.cs
│   │   ├── DbUserRepository.cs
│   │   ├── ICheckInRepository.cs
│   │   ├── IMessageRepository.cs
│   │   ├── IStudentTeacherRepository.cs
│   │   └── IUserRepository.cs
│   ├── Services
│   │   ├── ApplicationDbContext.cs
│   │   └── UserSession.cs
│   ├── StudentTrackerApp.csproj
│   ├── StudentTrackerApp.csproj.user
│   └── wwwroot
│       ├── app.css
│       ├── bootstrap
│       │   ├── bootstrap.min.css
│       │   └── bootstrap.min.css.map
│       ├── favicon.png
│       └── js
│           └── geoLocation.js
└── StudentTrackerApp.sln

```

---

## Setup Instructions

### Clone the repository

```
git clone git@github.com:SE1-Group-8/StudentTracker.git
cd StudentTracker
```

### Install the required .NET SDK version (6, 7, or 8)

#### Windows
If missing go to https://dotnet.microsoft.com/download

#### Linux

For Debian
```
wget https://packages.microsoft.com/config/debian/13/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
rm packages-microsoft-prod.deb
```

Ubuntu
```
sudo add-apt-repository ppa:dotnet/backports
sudo apt-get update && \
  sudo apt-get install -y dotnet-sdk-<version num>
sudo apt-get update && \
  sudo apt-get install -y aspnetcore-runtime-<version num>
```

openSUSE
```
sudo zypper install libicu
sudo rpm --import https://packages.microsoft.com/keys/microsoft.asc
wget https://packages.microsoft.com/config/opensuse/16/prod.repo
sudo mv prod.repo /etc/zypp/repos.d/microsoft-prod.repo
sudo chown root:root /etc/zypp/repos.d/microsoft-prod.repo
```

#### OS X
`brew install dotnet-sdk`
or
Obtain `.pkg`/binaries from the above [link](https://dotnet.microsoft.com/download)

### Configure the SQLite3 Connection String
Update the connection string in `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Data Source=studenttracker.db"
}
```

Or set it via environment variable:

```bash
export ConnectionStrings__DefaultConnection="Data Source=studenttracker.db"
```

### Run Database Migrations
Ensure Entity Framework tools are installed:

```bash
dotnet tool install --global dotnet-ef
```

Apply migrations:

```bash
dotnet ef database update
```

### Run the application

```
cd <Project Root>/StudentTrackerApp
dotnet build
dotnet run
```

Visit the `URL:port` provided to access the site.

---

## Future Enhancements

* More robust accessibility support
* Expanded analytics
* Richer communication and class management tools
* Optional mobile friendly layout or dedicated mobile version
* Improved visual dashboards

---

## Deployment Guide/Release Notes
Deployment/Release is handled through an automated CI/CD pipeline:

1. On push to release branch, build-and-release workflow triggered. The new commit will be built and tested.
2. Upon passing tests, Release package is built for publishing
3. Semantic Versioning is performed based on the "Bump Type" automatically determining versioning in the form of `v<MAJOR>.<MINOR>.<PATCH>`, the new tag is applied
4. Creates GitHub Release providing the `.zip` archive and `tar.gz` tarball packages
5. Release Notes/Changelog automatically generated for new Releases based on the [`release.yml`](.github/release.yml) configuration
  * This also performs semantic versioning so changelogs/release notes will be aligned and provide more detailed information

---

## Contributors

This application was developed collaboratively to explore real world full stack development using Blazor, modular architecture, and user centered design.
