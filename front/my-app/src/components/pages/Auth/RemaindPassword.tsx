import React from "react";
import Layout from "../../layout/Layout";
import { Box, Button, Card, TextField } from "@mui/material";
import "./../../../styles/pages/Auth/RemaindPassword.css"
const RemaindPassword = () => {

	return (
		<Layout>
			<Box className="remaind-password-main">
				<p className="remaind-password-title">Enter your email and we will send you a link to reset your password</p>
				<form className="remaind-password-form">

					<TextField
						id="standard-basic"
						label="Email"
						variant="standard"
						sx={{
							display: 'block',
						}}
					/>

					<Button
						variant="contained"
						onClick={() => (console.log("click"))}
						sx={{ display: 'block', marginTop: '20px' }}>Send email</Button>

				</form>
			</Box>
		</Layout >
	)
}

export default RemaindPassword