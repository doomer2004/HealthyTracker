import React, { FC, useEffect } from "react";
import { Box, Card, Button, Link } from "@mui/material";
import logo from "../../../../src/images/Logo_HTM.svg";
import "../../../styles/layout/header.css"
import { useNavigate } from "react-router-dom";
import { useUser } from "../../../contexts/UserContext";
import MenuAvatar from "../../home/MenuAvatar";

const Header: FC = () => {
    const { user, loading, updateUser, refreshUser } = useUser();
    const navigate = useNavigate();

    console.log(user)

    // useEffect(() => {
    //     refreshUser();
    // }, []);

    return (
        <Box className="page-wrapper">
            <Card className="header">
                <img className="header-logo" src={logo} />
                <Box className="header-nav">
                    <Link
                        href="/"
                        variant="h6"
                        color="inherit"
                        underline="hover">
                        Home
                    </Link>
                    <Link
                        href="/about"
                        variant="h6"
                        color="inherit"
                        underline="hover">
                        About
                    </Link>
                    <Link
                        href="/nutrition-calculator"
                        variant="h6"
                        color="inherit"
                        underline="hover">
                        Nutrition Calculator
                    </Link>
                    <Link
                        href="/id/my-nutrition"
                        variant="h6"
                        color="inherit"
                        underline="hover">
                        My Nutrition
                    </Link>
                </Box>
                <Box className="header-login">
                    {loading
                        ? <>Loading...</>
                        : (user ?
                            <MenuAvatar
                                onSignOut={() => { console.log('logout'); updateUser(null) }}
                                onProfile={() => navigate('/user-account')} />
                            :
                            <>
                                <Button variant="contained" onClick={() => navigate('/sign-in')}>Sign in</Button>
                                <Button variant="contained" onClick={() => navigate('/sign-up')}>Sign up</Button>
                            </>
                        )}
                </Box>
            </Card >

        </Box >
    )
}

export default Header

