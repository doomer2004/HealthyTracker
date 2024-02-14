import React from "react";
import { IUserData } from "./types";
import Layout from "../../layout/Layout";
import { Box, Button, FormHelperText, TextField } from '@mui/material';
import { GoogleLogin } from "@react-oauth/google";
import { useLocation, useNavigate } from "react-router-dom";
import { Error } from '@mui/icons-material';
import { useUser } from "../../../contexts/UserContext";
import useNotification from "../../../hooks/useNotification";
import { ConfirmEmailRequest, SignUpRequest } from "../../../models/api/request/AuthRequests";
import Auth from "../../../services/api/Auth";
import SignUpForm from "../../auth/sign-in/sign-up/SignUpForm";
import AuthGoogleButton from "../../google/SignInGoogle";


const SignUp = () => {
  const location = useLocation();
  const queryParams = new URLSearchParams(location.search);
  const adminToken = queryParams.get('adminToken') ?? undefined;

  const [userId, setUserId] = React.useState<string | undefined>(undefined);
  const { updateUser } = useUser();
  const navigate = useNavigate();

  const { notifyError, Notification } = useNotification();

  const signUp = async (request: SignUpRequest) => {
    const response = await Auth.signUp({ ...request });

    if (response !== undefined)
      setUserId(response.userId);
    else
      notifyError("Error during signing up");
  }

  const confirmEmail = async (request: ConfirmEmailRequest) => {
    const response = await Auth.confirmEmail(request);

    if (response === undefined) {
      const user = await Auth.me();
      if (user) {
        updateUser(user);
        navigate('/');
      } else {
        notifyError('Error during signing in');
      }
    }
    else {
      notifyError("Error during confirming email");
    }
  }

  return (
    <Layout>
      <Box className="main" sx={{ height: '80vh', display: 'flex', alignItems: 'center', justifyContent: 'center' }}>
        <Box className="sign-in-form">
          <SignUpForm onSubmit={(fields) => signUp(fields)} />
          <AuthGoogleButton label="Sign up with Google" type="sign-up" />
        </Box>
      </Box>

      <Notification />
    </Layout >
  )
};
export default SignUp;
