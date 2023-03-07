
I have added double exclamation `!!` mark in the code where special attention is needed, including `.csproj` and `.dcproj`

Tips :-
1. use `http://<image-name>/` instead of `http://localhost:5003/` to establish http client.\
   then only the communication between multi-containers will work seamlessly.\
   example : `http://customerservice/`
2. use `docker-compose up` to keep the container(s) up after they're stopped.\
   use `docker-compose down` to remove the container(s) after they're stopped.\
   use `docker-compose run`, the container is automatically removed when it exits.
