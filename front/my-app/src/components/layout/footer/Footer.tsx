import React, { FC } from "react";
import {Box, Card, Link} from "@mui/material";
import "../../../styles/layout/footer.css"
const Footer: FC = () => {
    return (
        <Box className="page-wrapper">
            <Card className="footer">
                <p className="footer-text">Danyil</p>
                <p className="footer-text">Hizhytskyi</p>
                <Link
                    href="/"
                    variant="h6"
                    color="inherit"
                    underline="none">
                    gitHub: doomer2004
                </Link>
            </Card>
        </Box>
    )
}

export default Footer