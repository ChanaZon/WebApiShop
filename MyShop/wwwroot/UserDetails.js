const title = document.querySelector("#title")
const user = JSON.parse(sessionStorage.getItem('currentUser'))
title.textContent = `hello ${user.userName}`

const GetDataFromForm = () => {
    const userName = document.querySelector("#updateUserNameInput").value
    const password = document.querySelector("#updatePasswordInput").value
    const firstName = document.querySelector("#updateFirstNameInput").value
    const lastName = document.querySelector("#updateLastNameInput").value
    return ({ userName, password, firstName, lastName });
}

const ShowDetails = () => {
    const container = document.querySelector("#details");
    container.style.visibility = "visible";
}
const UpdateUser = async() => {
    const UpdatedUser = GetDataFromForm();
    try {
        const ResponsePut = await fetch(`api/User/${user.userId}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(UpdatedUser)
        });
        //if status==400
        //weak password
        if (ResponsePut.ok) {
            alert("Updated successfully");
        } else {
            alert("Bad request");
        }
    }
    catch (Error) {
        console.log(Error)
    }
}