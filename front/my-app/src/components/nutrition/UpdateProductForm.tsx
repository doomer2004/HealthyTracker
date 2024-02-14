import { yupResolver } from "@hookform/resolvers/yup";
import { Box, TextField, Button } from "@mui/material";
import { UpdateProductFormFields } from "../../models/form/auth/UpdateProductFromFields";
import updateProductFormValidation from "../../validation/forms/UpdateProductFormValidation";
import { useForm } from "react-hook-form";
import { UpdateProductRequest } from "../../models/api/request/UpdateProductRequest";

interface UpdateProductFormProps {
	onSubmit: (data: UpdateProductRequest) => void;
}

export const UpdateProductForm = (props: UpdateProductFormProps) => {
	const {
		register,
		handleSubmit,
		formState: { errors },
	} = useForm<UpdateProductRequest>({
		reValidateMode: 'onChange',
		mode: 'onTouched'
	});

	return <Box onClick={(event) => event.stopPropagation()}
		sx={{ width: '100%', height: '10%' }}>
		<Box sx={{ width: '100%', height: '100%', display: 'flex', justifyContent: 'center', alignItems: 'center', flexDirection: 'column' }}>
			<form onSubmit={handleSubmit(props.onSubmit)}>
				<TextField
					id="volume"
					{...register('volume')}
					label="Volume (g)"
					variant="standard"
					type="number"
					error={Boolean(errors.volume)}
					helperText={errors.volume?.message}
				/>
				<Button
					type="submit"
					variant="contained"
					sx={{ marginTop: '10px' }}>Update</Button>
			</form>
		</Box>

	</Box>;
}