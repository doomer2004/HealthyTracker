import React, { FC, createContext, useEffect } from "react";
import Header from "./header/Header"
import Footer from "./footer/Footer"
import { Box } from "@mui/material";
import { UserProvider } from "../../contexts/UserContext";

interface Props {
    children: React.ReactNode
}

//ts ignore
const Layout = ({ children }: Props) => {
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
