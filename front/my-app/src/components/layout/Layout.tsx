import React, { FC } from "react";
import Header from "./header/Header"
import Footer from "./footer/Footer"
import {Box} from "@mui/material";

interface Props {
    children: React.ReactNode
} 

//ts ignore
const Layout = ({children} : Props) => {
    return (
        <>
            <Header />
            <Box
                sx={{ flexGrow: 1 }}>
                {children}
            </Box>
            <Footer />
        </>
    )
}

export default Layout
