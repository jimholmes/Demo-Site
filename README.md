Demo-Site
=========

A site I use for various demonstrations of common test automation problems.

# Setup
It's kludgy ATM. 

0) Run CreateDB.sql
1) Run CreateContacts.sql
2) Run InsertContacts.sql

Add site as an app in IIS.

# Overview

## UI for testing
WebApi/Views/Home/Index uses a Telerik grid to render contacts
WebApi/KendoGrid uses a Kendo Grid to render contacts. Supports edit and create.

## Services API
REST services are exposed out via WebApi for regular PUT/POST/GET stuff (used by both grids above).

There's a WCF service for SOAP endpoint testing. 

## Backing API
SupportApi project is a start on demoing how to use a backing API to help make functional testing easier.

# Testability

WebApi/KendoGrid-*.html are progressive files meant to show how to make the system more testable.

* Grid-1 is default Kendo grid. Look at dynamic IDs on table.
* Grid-2 adds a Create button to make new contacts.
* Grid-3 changes grid IDs so they're unique with the row number. Not the best. 
* Grid-4 changes IDs so they are DB ID + last name.
