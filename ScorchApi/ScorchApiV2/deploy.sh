#!/bin/bash

dotnet publish -o site
zip -r site.zip site