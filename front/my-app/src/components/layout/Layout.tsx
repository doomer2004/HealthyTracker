import React, { FC, createContext, useEffect } from "react";
import Header from "./header/Header"
import Footer from "./footer/Footer"
import { Box } from "@mui/material";
import { UserProvider, useUser } from "../../contexts/UserContext";
import { useNavigate } from "react-router-dom";

interface Props {
    children: React.ReactNode
}

//ts ignore
const Layout = ({ children }: Props) => {

    const { user, loading, updateUser, refreshUser } = useUser();
    const navigate = useNavigate();

    useEffect(() => {
        refreshUser();
    }, []);

    return (
        <>
            <UserProvider children=
                {
                    <>
                        <Header />
                        <Box
                            sx={{ flexGrow: 1 }}>
                            {children}
                        </Box>
                        <Footer />
                    </>
                } />
        </>
    )
}

export default Layout
