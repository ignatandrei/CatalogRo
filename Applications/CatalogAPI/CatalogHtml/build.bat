rem call ng build --prod --build-optimizer
robocopy . D:\github\CatalogRo\Applications\CatalogAPI\CatalogHtml  /MIR /XD node_modules .git .vs

robocopy dist D:\github\CatalogRo\Applications\CatalogAPI\CatalogAPI\wwwroot  /MIR /XD node_modules .git .vs