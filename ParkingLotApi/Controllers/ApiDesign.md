URL: parkinglots

Method: Post

request body: 

"""json
{
    name: "post",
    capacity: 10,
    location: "hh"
}
"""

response code: httpstatuscode.created / badrequest

response body: 

"""json
{
    id: guid
    name: "post",
    capacity: 10,
    location: "hh"
}
"""