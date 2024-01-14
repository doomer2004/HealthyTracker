import React from "react";
import Layout from "../layout/Layout";
import { Box } from "@mui/material";
import "../../styles/pages/about.css"
const About = () => {
	return (
		<Layout>
			<Box className="about-main">
				<Box sx={{ typography: 'body1', textAlign: 'center', m: 3 }}>
					<h1 className="about-title">About Our Web App</h1>
					<p>
						Our goal is to empower individuals on their journey to a healthier lifestyle.
						We provide tools and resources that make nutrition tracking and fitness management
						accessible and effective.<br /> We believe that with the right support, anyone can
						reach their wellness objectives.
					</p>
					<p>
						"To uncover your true potential you must first find your own limits and then you
						have to have the courage to blow past them." <br /> Picabo Street, Olympic Gold Medalist
					</p>
					<p>
						"Success usually comes to those who are too busy to be looking for it." <br /> Henry David Thoreau, Philosopher
					</p>
					<p>
						"The only place where success comes before work is in the dictionary." <br /> Vidal Sassoon, Hairstylist and Businessman
					</p>
				</Box>
			</Box>
		</Layout>
	)
}

export default About