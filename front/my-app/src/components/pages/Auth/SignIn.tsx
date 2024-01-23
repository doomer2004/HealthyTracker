import React from "react";
import { IUserData } from "./types";
import Layout from "../../layout/Layout";
import { Box, Button, FormHelperText, TextField } from '@mui/material';
import { GoogleLogin } from "@react-oauth/google";
import { useNavigate } from "react-router-dom";
import { client } from '../../../services/api';
import { Error } from '@mui/icons-material';


const SignIn = () => {
    const [userData, setUserData]
        = React.useState<IUserData>({
            firstName: '',
            lastName: '',
            email: '',
            password: '',
            confirmPassword: '',
        } as IUserData);

    const [errors, setErrors] = React.useState<IUserData>({
        firstName: '',
        lastName: '',
        email: '',
        password: '',
        confirmPassword: '',
    } as IUserData);

    const handleInputChange = (event: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) => {
      const { name, value } = event.target;
      setUserData(prev => ({ ...prev, [name]: value }));
      setErrors(prev => ({ ...prev, [name]: '' }));
    }

    const responseMessage = (response: any) => {
        console.log(response);
    };
    const errorMessage = (error: any) => {
        console.log(error);
    };

    const handleLogin = async (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault();
        await client.signUp({
          email: userData.email,
          password: userData.password,
          firstName: userData.firstName,
          lastName: userData.lastName,
        }).catch((error) => {
          const keys = Object.keys(error.body);
          for (const key of keys) {
            const keyToLowerCase = key[0].toLowerCase() + key.slice(1);
            setErrors(prev => ({ ...prev, [keyToLowerCase]: error.body[key] }));
          }
        });
    }
    const inputs = [
      {
        label: 'First Name',
        name: 'firstName',
        type: 'text',
      },
      {
        label: 'Last Name',
        name: 'lastName',
        type: 'text',
      },
      {
        label: 'Email',
        name: 'email',
        type: 'email',
      },
      {
        label: 'Password',
        name: 'password',
        type: 'password',
      },
      {
        label: 'Confirm Password',
        name: 'confirmPassword',
        type: 'password',
      }];
    const navigate = useNavigate();

    return (
        <Layout>
            <Box className="main" sx={{ height: '80vh', display: 'flex', alignItems: 'center', justifyContent: 'center' }}>
                <form className="sign-in-form" onSubmit={handleLogin}>
                    <p className="sign-in-title">Sign in</p>
                  {inputs.map((input, index) => (
                    <>
                    <TextField className="sign-in-input"
                      id="standard-basic"
                      label={input.label} type={input.type}
                      variant="standard" name={input.name}
                      value={userData[input.name as keyof IUserData]}
                      sx={{
                        display: 'block',
                        marginTop: '20px'
                      }}
                      onChange={e => handleInputChange(e)}
                    >
                    </TextField>
                      {errors[input.name as keyof IUserData] && <FormHelperText sx={{ color: 'red', width: '60%', wordBreak: 'break-word' }}>{errors[input.name as keyof IUserData]}</FormHelperText>}
                    </>
                  ))
                  }
                    <Button sx={{
                        marginTop: '20px',
                        alignItems: 'center',
                        margin: '20px 0',
                        fontSize: '16px',
                    }}
                        type="submit"
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
