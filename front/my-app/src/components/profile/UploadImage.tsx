import { Avatar, Box, Button, IconButton } from "@mui/material";
import { UploadImageProps } from "./UploadImage.types";

const UploadImage: React.FC<UploadImageProps> = (
	{
		inputFile,
		url,
		handleFileUpload,
		handleDeleteFile,
	}
) => {

	const avatarOverridingStyles = {
		height: '200px',
		width: '200px'
	}

	return (
		<Box
		>
			<input
				style={{ display: "none" }}
				accept=".jpeg,.png,.jpg"
				ref={inputFile}
				onChange={handleFileUpload}
				type="file"
			/>
			<IconButton
				onClick={() => (inputFile?.current as HTMLInputElement | null)?.click()}>
				<Avatar
					sx={avatarOverridingStyles}
					src={url}
					alt="Profile Avatar" />
			</IconButton>
			{!url.includes('Default') && (
				<Button style={{ marginLeft: '50px' }}
					size="small" onClick={handleDeleteFile}>Delete Avatar</Button>
			)}
		</Box>
	);
};
export default UploadImage