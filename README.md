
# gfcf14's Art FrontEnd
This repository is the frontend part of my gfcf14's Art project. You can find the backend part [here](https://github.com/gfcf14/gfcf14-art-backend).

## Description
The gfcf14's Art frontend project is a [simple website](https://gfcf14-art-cjhfgxdxe8c6eree.eastus2-01.azurewebsites.net/) which fetches records from a remote database to display my drawn artworks sorted by date, or a specific record from a specific page as noted by the artwork date to display a single artwork in a detail page. The project also features a simple about page with links to my social media sites, and a create page behind authentication, where only an authorized user (me) would be able to access to create new records, i.e. every time I post a new drawn artwork online.

## Purpose
I created these repositories to leverage the hosting of my drawings and artworks from different social media sites, where I regularly post these images but these are mixed with other works. As such, I wanted to have a space where I could only show the artworks.

## Basic Data Flow
![enter image description here](https://github.com/gfcf14/gfcf14-art/blob/main/wwwroot/assets/gfcf14art-simple-flow.jpg?raw=true)
This application consists of a linear, layered architecture with a simple frontend application developed in Blazor, which communicates with a backend server in ASP.NET, which in turn communicates with a remote PostgreSQL database hosted in Supabase.  

## Complete Data Flow
![enter image description here](https://github.com/gfcf14/gfcf14-art/blob/main/wwwroot/assets/gfcf14art-complete-flow.jpg?raw=true)
The complete data flow in the frontend involves 3 out of the 4 routes available (5 if counting the [404 page](https://gfcf14-art-cjhfgxdxe8c6eree.eastus2-01.azurewebsites.net/404)), in which the blue arrows indicate downstream data flow and the red arrows indicate data moving upstream. The frontend application depends on 2 major services. The artwork service is in charge of communicating with the backend for the routes `/`, `/:date`, `/create` to call the endpoints which fetch the appropriate artwork records in the database, either all or by date, or in the case of creating a new artwork. The login service is the one that keeps basic auth in place, the main idea is to send the appropriate credentials to the backend to compare with the database, since accessing the `/create` route prompts the user to log in. If successful, the login form hides to show a create form, which when filled out performs a post request to create a new artwork.

Please note this is the explanation of data flow for the frontend part. If you wish to read on the backend part, please go [here](https://github.com/gfcf14/gfcf14-art-backend).

## Considerations
Since this is a personal project, I decided to develop and host my apps for free. As such, the frontend application is hosted in Azure's free tier, the backend is hosted via Azure's free tier, and the database is hosted using Supabase's free tier. However, though each of these deployments is successful, sometimes I have experienced delays in operations due to cold start times. Considering how this diminishes user experience, I have decided on an alternative approach that is virtually cold-start free, but instead utilizes an extendable [shared backend architecture](https://github.com/gfcf14/gfcf14-sba) hosted in Vercel to leverage their minimal cold start time.