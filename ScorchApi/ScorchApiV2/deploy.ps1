dotnet publish -o site
7z a site.zip .\site\*
7z a package.zip site.zip aws-windows-deployment-manifest.json
eb deploy 

rm site.zip 
rm package.zip
rm -Recurse site