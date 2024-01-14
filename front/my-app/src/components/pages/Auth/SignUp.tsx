import React from "react";
import { ILoginData } from "./types";
import Layout from "../../layout/Layout";
import { Box, Button, Card, TextField } from "@mui/material";
import "./../../../styles/pages/Auth/signIn.css"
import { GoogleLogin } from "@react-oauth/google";
import { useNavigate } from "react-router-dom";
const SignUp = () => {
    const [loginData, setLoginData]
        = React.useState<ILoginData>({
            email: '',
            password: '',
        } as ILoginData);

    const responseMessage = (response: any) => {
        console.log(response);
    };
    const errorMessage = (error: any) => {
        console.log(error);
    };

    const handleLogin = (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault()
        console.log(loginData.email, loginData.password)
    }
    const navigate = useNavigate();

    return (
        <Layout>
            <Box className="main" sx={{ height: '80vh', display: 'flex', alignItems: 'center', justifyContent: 'center' }}>
                <form className="sign-in-form" onSubmit={handleLogin}>
                    <p className="sign-in-title">Sign up</p>
                    <TextField
                        id="standard-basic"
                        label="Email"
                        variant="standard"
                        value={loginData.email}
                        sx={{
                            display: 'block',
                            marginTop: '20px'
                        }}
                        onChange={e => setLoginData({ ...loginData, email: e.target.value })}
                    />
                    <TextField
                        id="standard-basic"
                        type="password"
                        label="Password"
                        variant="standard"
                        value={loginData.password}
                        sx={{
                            display: 'block',
                            marginTop: '20px'
                        }}
                        onChange={e => setLoginData({ ...loginData, password: e.target.value })}
                    />
                    <Button sx={{
                        marginTop: '20px',
                        alignItems: 'center',
                        margin: '20px 0',
                        fontSize: '16px',
                    }}
                        onClick={() => console.log(loginData)}
                    >
                        Sign up
                    </Button>

                    <Button
                        onClick={() => navigate('/remaind-password')}
                        sx={{
                            marginTop: '20px',
                            alignItems: 'center',
                            margin: '20px 0',
                            fontSize: '16px',
                        }}
                    >
                        Remaind password?
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
export default SignUp;