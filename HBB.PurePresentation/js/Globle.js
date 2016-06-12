var Globle={};

Globle.baseUrl = "http://localhost/HBBAPI/";



// fetch api 帮助方法
Globle.checkStatus = function(response) 
{
  if (response.status >= 200 && response.status < 300) {
    return response
  } else {
    var error = new Error(response.statusText)
    error.response = response
    throw error
  }
}

Globle.parseJSON = function(response) 
{
  return response.json()
}


module.exports=Globle;