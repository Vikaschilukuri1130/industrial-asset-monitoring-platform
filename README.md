# Industrial Asset Monitoring Platform

## Overview

The Industrial Asset Monitoring Platform is a full-stack ASP.NET Core application designed to monitor industrial equipment, process sensor readings, generate alerts, calculate health scores, and provide maintenance recommendations. The platform helps organizations improve operational efficiency, reduce downtime, and support predictive maintenance initiatives through real-time monitoring and intelligent decision-making.

---

## Features

### Asset Management

* Create and manage industrial assets.
* Track asset status, location, and maintenance history.
* Maintain installation and maintenance records.

### Sensor Monitoring

* Capture and store sensor readings.
* Monitor temperature, pressure, vibration, and runtime metrics.
* Maintain historical sensor data for analysis.

### Health Score Calculation

* Evaluate equipment health based on sensor values.
* Identify potential equipment degradation.
* Support predictive maintenance strategies.

### Alert Generation

* Automatically generate alerts when thresholds are exceeded.
* Categorize alerts by severity levels.
* Maintain historical alert records.

### Maintenance Recommendations

* Analyze sensor readings.
* Generate maintenance recommendations.
* Support proactive maintenance planning.

### RESTful APIs

* Fully documented using Swagger/OpenAPI.
* CRUD operations for assets and sensor readings.
* Dashboard-ready architecture.

---

## Technology Stack

### Backend

* ASP.NET Core 8 Web API
* C#

### Database

* Microsoft SQL Server Express
* Entity Framework Core 8

### API Documentation

* Swagger / OpenAPI

### Source Control

* Git
* GitHub

---

## System Architecture

```text
Client / Swagger UI
        |
        V
Controllers
        |
        V
Business Services
        |
        V
Entity Framework Core
        |
        V
ApplicationDbContext
        |
        V
SQL Server Database
```

---

## Project Structure

```text
industrial-asset-monitoring-platform
│
├── backend
│   └── AssetMonitoring.API
│       ├── Controllers
│       │   ├── AssetsController.cs
│       │   └── SensorReadingsController.cs
│       │
│       ├── Models
│       │   ├── Asset.cs
│       │   ├── SensorReading.cs
│       │   └── AssetAlert.cs
│       │
│       ├── Services
│       │   ├── AlertService.cs
│       │   ├── HealthScoreService.cs
│       │   └── MaintenanceRecommendationService.cs
│       │
│       ├── Data
│       │   └── ApplicationDbContext.cs
│       │
│       ├── Program.cs
│       ├── appsettings.json
│       └── AssetMonitoring.API.csproj
│
├── database
├── docs
└── README.md
```

---

## Database Schema

### Assets Table

| Column              | Data Type |
| ------------------- | --------- |
| AssetId             | INT       |
| AssetName           | NVARCHAR  |
| AssetType           | NVARCHAR  |
| Location            | NVARCHAR  |
| Status              | NVARCHAR  |
| InstalledDate       | DATETIME  |
| LastMaintenanceDate | DATETIME  |

### SensorReadings Table

| Column          | Data Type |
| --------------- | --------- |
| SensorReadingId | INT       |
| AssetId         | INT       |
| Temperature     | FLOAT     |
| Pressure        | FLOAT     |
| Vibration       | FLOAT     |
| RuntimeHours    | FLOAT     |
| ReadingTime     | DATETIME  |

### AssetAlerts Table

| Column      | Data Type |
| ----------- | --------- |
| AlertId     | INT       |
| AssetId     | INT       |
| AlertType   | NVARCHAR  |
| Message     | NVARCHAR  |
| Severity    | NVARCHAR  |
| CreatedDate | DATETIME  |

---

## Implemented APIs

### Asset APIs

| Method | Endpoint         | Description          |
| ------ | ---------------- | -------------------- |
| GET    | /api/Assets      | Retrieve all assets  |
| GET    | /api/Assets/{id} | Retrieve asset by ID |
| POST   | /api/Assets      | Create a new asset   |

### Sensor Reading APIs

| Method | Endpoint            | Description                      |
| ------ | ------------------- | -------------------------------- |
| GET    | /api/SensorReadings | Retrieve all sensor readings     |
| POST   | /api/SensorReadings | Process and save sensor readings |

### Alert APIs

| Method | Endpoint                   | Description               |
| ------ | -------------------------- | ------------------------- |
| GET    | /api/SensorReadings/alerts | Retrieve generated alerts |

---

## Health Score Logic

The Health Score Engine evaluates equipment condition using multiple sensor parameters.

Factors considered:

* Temperature
* Pressure
* Vibration

Higher sensor readings indicate increased equipment stress and result in lower health scores.

Example:

```text
Temperature ↑
Pressure ↑
Vibration ↑
      ↓
Health Score ↓
```

---

## Alert Generation Logic

Alerts are automatically generated when sensor values exceed predefined thresholds.

Example:

```text
Temperature > Threshold
        ↓
Generate High Severity Alert
```

Sample Alert:

```json
{
  "alertId": 1,
  "assetId": 1,
  "alertType": "Temperature",
  "message": "Critical temperature threshold exceeded.",
  "severity": "High"
}
```

---

## Maintenance Recommendation Logic

The Maintenance Recommendation Engine analyzes equipment conditions and generates actionable recommendations.

Example:

```text
High Temperature
        ↓
Immediate Maintenance Required
```

Sample Recommendation:

```text
Immediate maintenance required due to high temperature.
```

---

## Sample Asset Request

```json
{
  "assetName": "Compressor Unit A1",
  "assetType": "Compressor",
  "location": "Plant 1",
  "status": "Operational",
  "installedDate": "2024-01-15T00:00:00",
  "lastMaintenanceDate": "2026-05-01T00:00:00"
}
```

---

## Sample Sensor Reading Request

```json
{
  "assetId": 1,
  "temperature": 96,
  "pressure": 145,
  "vibration": 82,
  "runtimeHours": 4500,
  "readingTime": "2026-05-30T00:00:00"
}
```

---

## Example Sensor Processing Response

```json
{
  "message": "Sensor reading processed and saved successfully",
  "healthScore": 50,
  "recommendation": "Immediate maintenance required due to high temperature.",
  "alertGenerated": true
}
```

---

## Setup Instructions

### Clone Repository

```bash
git clone https://github.com/<your-github-username>/industrial-asset-monitoring-platform.git
```

### Navigate to Project

```bash
cd industrial-asset-monitoring-platform/backend/AssetMonitoring.API
```

### Restore Dependencies

```bash
dotnet restore
```

### Build Application

```bash
dotnet build
```

### Run Application

```bash
dotnet run
```

---

## Swagger Documentation

Once the application starts, open:

```text
http://localhost:5013/swagger
```

Swagger provides interactive API documentation and testing capabilities.

---

## Project Achievements

✔ SQL Server database integration completed

✔ Entity Framework Core integration completed

✔ Asset Management APIs completed

✔ Sensor Reading Processing completed

✔ Automated Alert Generation completed

✔ Health Score Calculation completed

✔ Maintenance Recommendation Engine completed

✔ Swagger API Documentation completed

✔ End-to-End Testing completed

---

## Future Enhancements

### Dashboard & Visualization

* Power BI Dashboard Integration
* Real-time Monitoring Dashboard
* Alert Analytics Dashboard

### Authentication & Security

* JWT Authentication
* Role-Based Access Control (RBAC)

### Advanced Analytics

* Predictive Maintenance Models
* Machine Learning-Based Failure Prediction
* Remaining Useful Life (RUL) Estimation

### Cloud Deployment

* Azure App Service
* Azure SQL Database
* Docker Containerization
* CI/CD Pipelines

---

## Author

**Vikas Mohan Chilukuri**

Software Engineer | Data Engineer | Business Analytics Graduate

---

## License

This project is licensed under the MIT License.
