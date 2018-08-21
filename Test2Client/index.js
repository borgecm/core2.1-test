let push_recruiter = (recruiter) => {
  let recruiters_list = document.getElementById("recruiters-list")
  var li = document.createElement("li");
  li.appendChild(document.createTextNode(recruiter));
  recruiters_list.appendChild(li);
}

fetch('https://localhost:44387/api/Recruiter')
  .then(function(response) {
    return response.json();
  })
  .then(function(myJson) {
    console.log(myJson);
    
    myJson.map(recruiter => {
      push_recruiter(recruiter.name)
    })
  });


  const hubConnection = new signalR.HubConnectionBuilder()
  .withUrl("https://localhost:44387/recruiterhub")
  .configureLogging(signalR.LogLevel.Information)
  .build()

  hubConnection.on("Add", (value) => {
    push_recruiter(value)
  });
  hubConnection.start();



let post_recruiter = () => {
    recruiter_name = document.getElementById("new-recruiter").value;
    let data = {
        name: recruiter_name
    }
    fetch('https://localhost:44387/api/Recruiter', {
        method: 'POST', // or 'PUT'
        body: JSON.stringify(data), // data can be `string` or {object}!
        headers:{
          'Content-Type': 'application/json'
        }
      })
}