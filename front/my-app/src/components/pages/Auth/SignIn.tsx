import React, { FormEventHandler } from 'react';
import { ILoginData } from "./types";
import Layout from "../../layout/Layout";
import { Box, Button, Card, TextField } from "@mui/material";
import "./../../../styles/pages/Auth/signIn.css"
import { GoogleLogin } from "@react-oauth/google";
import { useNavigate } from "react-router-dom";
import { useUser } from '../../../contexts/UserContext';
import useNotification from '../../../hooks/useNotification';
import { SignInFormFields } from '../../../models/form/auth/AuthFormFields';
import Auth from '../../../services/api/Auth';
import SignInForm from '../../auth/sign-in/SignInForm';
import AuthGoogleButton from '../../google/SignInGoogle';

const SignIn = () => {
    const { refreshUser } = useUser();
    const { notifyError, Notification } = useNotification();
    const navigate = useNavigate();

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

    // const handleLogin = async () => {
    //     await client.signIn({
    //         email: loginData.email,
    //         password: loginData.password,
    //     }).then((x: any) => {
    //         localStorage.setItem('accessToken', x.accessToken);
    //         localStorage.setItem('refreshToken', x.refreshToken);
    //     }).then(() => {
    //         window.location.href = '/nutrition-calculator';
    //     });
    // }

    const onSubmit = async (fields: SignInFormFields) => {
        console.log('onSubmit', fields)
        const error = await Auth.signIn({ ...fields });
        if (!error) {
            const user = refreshUser();
            if (!user) notifyError('Error during signing in') 
            else 
                {navigate('/')};
        }

        notifyError(error?.message ?? 'Error during signing in');
    };


    return (
        <Layout>
            <Box className="main" sx={{ height: '80vh', display: 'flex', alignItems: 'center', justifyContent: 'center' }}>
                <Box className="sign-in-form">
                    <SignInForm onSubmit={onSubmit} />
                    <AuthGoogleButton label="Sign up with Google" type="sign-in" />
                </Box>
            </Box>

            <Notification />
        </Layout>
    )
};
export default SignIn;
