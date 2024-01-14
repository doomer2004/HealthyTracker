import React, { FC } from "react";
import { useNavigate } from "react-router-dom";
import { Box, Button, Link } from "@mui/material";
import logo from "../../images/main-logo.svg"
import "../../styles/pages/home.css"
import Layout from "../layout/Layout";
const Home = () => {
    const navigate = useNavigate();

    return (
        <Layout>
            <Box className="home-main">
                <h1 className="main-title">Healthy Tracker</h1>
                <Box className="main-content">
                    <img src={logo} className="main-logo" />
                    <Box className="main-text">
                        <h1 className="main-title">Nutrition is the first step to your health</h1>
                        <h3 className="main-subtitle">We will help you achieve the desired results without harming your body</h3>
                    </Box>
                </Box>
                <Box className="main-login">
                    <h1 className="main-title">TRY FOR FREE</h1>
                    <Box className="main-login-links">
                        <Button variant="contained" className="main-login-link" onClick={() => navigate('/sign-in')}>Sign in</Button>
                        <Button variant="contained" className="main-login-link" onClick={() => navigate('/sign-up')}>Sign up</Button>
                    </Box>
                </Box>
            </Box>
        </Layout>
    )
}

export default Home