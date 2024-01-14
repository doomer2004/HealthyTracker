import React from "react";
import Layout from "../../layout/Layout";
import { Box, TextField, Button } from "@mui/material";
import { IChangePasswordData } from "./types";

const ChangePassword = () => {

	const [changePasswordData, setChangePasswordData]
		= React.useState<IChangePasswordData>({
			oldPassword: '',
			newPassword: '',
		} as IChangePasswordData);


	const handlePassword = (e: React.FormEvent<HTMLFormElement>) => {
		e.preventDefault();
		console.log(changePasswordData);
	}

	return (
		<Layout>
			<Box>
				<Box className="main" sx={{ height: '80vh', display: 'flex', alignItems: 'center', justifyContent: 'center' }}>
					<form className="sign-in-form" onSubmit={handlePassword}>
						<p className="sign-in-title">Create your new password</p>
						<TextField
							id="standard-basic"
							label="Old Password"
							variant="standard"
							value={changePasswordData.oldPassword}
							sx={{
								display: 'block',
								marginTop: '20px'
							}}
							onChange={e => setChangePasswordData({ ...changePasswordData, oldPassword: e.target.value })}
						/>
						<TextField
							id="standard-basic"
							type="password"
							label="New Password"
							variant="standard"
							value={changePasswordData.newPassword}
							sx={{
								display: 'block',
								marginTop: '20px'
							}}
							onChange={e => setChangePasswordData({ ...changePasswordData, newPassword: e.target.value })}
						/>
						<Button sx={{
							alignItems: 'center',
							margin: '20px 0',
							fontSize: '16px',
						}}
							onClick={() => console.log(changePasswordData)}
						>
							Change Password
						</Button>


					</form>
				</Box>
			</Box>
		</Layout>
	)
}

export default ChangePassword