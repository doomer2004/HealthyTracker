import React, { FC } from "react";
import {Box, Card, Button, Link} from "@mui/material";
import logo from "../../../../src/images/Logo_HTM.svg";
import "../../../styles/layout/header.css"
const Header: FC = () => {
    return (
        <Box className="page-wrapper">
            <Card className="header">
                <Link
                    href="/"
                      variant="h6"
                      color="inherit"
                      underline="none">
                </Link>
                <img className="header-logo" src={logo}/>
                <Box className="header-nav">
                    <Link
                        href="/"
                          variant="h6"
                          color="inherit"
                          underline="none">
                        Home
                    </Link>
                    <Link
                        href="/"
                          variant="h6"
                          color="inherit"
                          underline="none">
                        About
                    </Link>
                    <Link
                        href="/"
                        variant="h6"
                        color="inherit"
                        underline="none">
                        Nutrition Calculator
                    </Link>
                    <Link
                        href="/"
                        variant="h6"
                        color="inherit"
                        underline="none">
                        My Nutrition
                    </Link>
                </Box>
                <Box className="header-login">
                    <Button variant="contained">Sign in</Button>
                    <Button variant="contained">Sign up</Button>
                </Box>
            </Card>

        </Box>
    )
}

export default Header