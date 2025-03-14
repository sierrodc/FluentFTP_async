﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Containers;

namespace FluentFTP.Xunit.Docker.Containers {
	internal class GlFtpdContainer : DockerFtpContainer {

		public GlFtpdContainer() {
			ServerType = FtpServer.glFTPd;
			ServerName = "glftpd";
			DockerImage = "glftpd:fluentftp";
			DockerImageOriginal = "jonarin/glftpd";
			DockerGithub = "https://github.com/jonathanbower/docker-glftpd";
			//RunCommand = "docker run --name=glFTPd --net=host -e GL_PORT=21 -e GL_RESET_ARGS=<arguments> glftpd:fluentftp";
			FixedUsername = "glftpd";
			FixedPassword = "glftpd";
		}

		/// <summary>
		/// For help creating this section see https://github.com/testcontainers/testcontainers-dotnet#supported-commands
		/// </summary>
		public override ITestcontainersBuilder<TestcontainersContainer> Configure(ITestcontainersBuilder<TestcontainersContainer> builder) {
			builder = builder
				.WithEnvironment("GL_PORT", "21");
			//todo fails during build. Unknown cause.
			return builder;
		}
	}
}
