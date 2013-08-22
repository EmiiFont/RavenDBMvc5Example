RavenDBMvc5Example
==================

Introduction

This is a sample ASP.NET MVC5 application that uses RavenDB as the database / persistence store using ninject
as the IoC to show how to implement and use it with ravenDB, I've used the default mvc5 template which is boostrap,
I'm not putting much energy into the UI. also knockoutJS for the html table binding.

What it Does

List in a simple html table some records.
Add to the database a record

What it Uses

RavenDb v2.5.2666 (Client and Server)
ASP.NET MVC5
Ninject for IoC
An attempt to simulate a production solution layout (eg. IoC, Service, Core)

What it is NOT

A best practice application. I'm a noob, so this is a learning experience.

For running you need to run first the ravenDB server located at /packages/RavenDB.Server.2.5.2666/tools and run the
Raven.Server.exe. you are good to go. :)
