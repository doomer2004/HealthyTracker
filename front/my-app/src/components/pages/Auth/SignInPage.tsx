import React from "react";
import {IUserData} from "./types";
import Layout from "../../layout/Layout";


const SignInPage = () => {
    const [userData, setUserData]
        = React.useState<IUserData>({
        firstName: '',
        lastName: '',
        email: '',
        password: '',
    } as IUserData);

    const handleLogin = (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault()
        console.log(userData.email, userData.password)
    }

    return (
        <Layout>
            <form onSubmit={handleLogin}>
                <h1>Sign in</h1>
                <input
                    type="firstName"
                    name="firstName"
                    placeholder="First Name"
                    value={userData.firstName}
                    onChange={event => setUserData({...userData, firstName: event.target.value})}/>
                <input
                    type="lastName"
                    name="lastName"
                    placeholder="Last Name"
                    value={userData.lastName}
                    onChange={event => setUserData({...userData, lastName: event.target.value})}/>
                <input
                    type="email"
                    name="email"
                    placeholder="Email"
                    value={userData.email}
                    onChange={event => setUserData({...userData, email: event.target.value})}/>
                <input
                    type="password"
                    name="password"
                    placeholder="Password"
                    value={userData.password}
                    onChange={event => setUserData({...userData, password: event.target.value})}/>
                <button type="submit">Sign in</button>
            </form>
        </Layout>
    )
};
export default SignInPage;