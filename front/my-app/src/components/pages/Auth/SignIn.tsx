import React from "react";
import { IUserData } from "./types";
import Layout from "../../layout/Layout";
import { Box, Button, TextField } from "@mui/material";
import { GoogleLogin } from "@react-oauth/google";
import { useNavigate } from "react-router-dom";


const SignIn = () => {
    const [userData, setUserData]
        = React.useState<IUserData>({
            firstName: '',
            lastName: '',
            email: '',
            password: '',
            confirmPassword: '',
        } as IUserData);

    const responseMessage = (response: any) => {
        console.log(response);
    };
    const errorMessage = (error: any) => {
        console.log(error);
    };

    const handleLogin = (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault()
        console.log(userData.email, userData.password)
    }

    const navigate = useNavigate();

    return (
        <Layout>
            <Box className="main" sx={{ height: '80vh', display: 'flex', alignItems: 'center', justifyContent: 'center' }}>
                <form className="sign-in-form" onSubmit={handleLogin}>
                    <p className="sign-in-title">Sign in</p>
                    <TextField className="sign-in-input"
                        id="standard-basic"
                        label="First name"
                        variant="standard"
                        value={userData.firstName}
                        sx={{
                            display: 'block',
                            marginTop: '20px'
                        }}
                        onChange={e => setUserData({ ...userData, firstName: e.target.value })}
                    />
                    <TextField
                        id="standard-basic"
                        label="Last name"
                        variant="standard"
                        value={userData.lastName}
                        sx={{
                            display: 'block',
                            marginTop: '20px',
                        }}
                        onChange={e => setUserData({ ...userData, lastName: e.target.value })}
                    />
                    <TextField
                        id="standard-basic"
                        label="Email"
                        variant="standard"
                        value={userData.email}
                        sx={{
                            display: 'block',
                            marginTop: '20px'
                        }}
                        onChange={e => setUserData({ ...userData, email: e.target.value })}
                    />
                    <TextField
                        id="standard-basic"
                        type="password"
                        label="Password"
                        variant="standard"
                        value={userData.password}
                        sx={{
                            display: 'block',
                            marginTop: '20px'
                        }}
                        onChange={e => setUserData({ ...userData, password: e.target.value })}
                    />
                    <TextField
                        id="standard-basic"
                        type="password"
                        label="Confirm password"
                        variant="standard"
                        value={userData.confirmPassword}
                        sx={{
                            display: 'block',
                            marginTop: '20px'
                        }}
                        onChange={e => setUserData({ ...userData, confirmPassword: e.target.value })}
                    />
                    <Button sx={{
                        marginTop: '20px',
                        alignItems: 'center',
                        margin: '20px 0',
                        fontSize: '16px',
                    }}
                        onClick={() => console.log(userData)}
                    >
                        Sign in
                    </Button>

                    <Button sx={{
                        marginTop: '20px',
                        alignItems: 'center',
                        margin: '20px 0',
                        fontSize: '16px',
                    }}
                        onClick={() => navigate('/sign-up')}
                    >
                        Already have an account? Sign up
                    </Button>

                    <GoogleLogin
                        onSuccess={responseMessage}
                        onError={() => errorMessage("Error")}
                    />
                </form>
            </Box>


        </Layout>
    )
};
export default SignIn;