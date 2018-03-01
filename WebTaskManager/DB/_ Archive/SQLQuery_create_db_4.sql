CREATE TABLE [TaskItem] (
	task_id integer NOT NULL,
	task_name varchar(256) NOT NULL,
	list_id integer NOT NULL,
	order_in_list integer NOT NULL UNIQUE,
	is_favorite BIT NOT NULL DEFAULT '0',
	task_description text,
	schedule_id integer NOT NULL,
	priority_id integer NOT NULL,
	tag_id integer NOT NULL,
	status_id integer NOT NULL,
	user_id integer NOT NULL,
	doer_id integer NOT NULL,
	creation_date datetime NOT NULL,
	delete_date datetime NOT NULL,
  CONSTRAINT [PK_TASKITEM] PRIMARY KEY CLUSTERED
  (
  [task_id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Status] (
	status_id integer NOT NULL,
	status_name varchar(32) NOT NULL UNIQUE,
  CONSTRAINT [PK_STATUS] PRIMARY KEY CLUSTERED
  (
  [status_id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Priority] (
	priority_id integer NOT NULL,
	priority_name varchar(64) NOT NULL UNIQUE,
	priority_rank integer NOT NULL,
  CONSTRAINT [PK_PRIORITY] PRIMARY KEY CLUSTERED
  (
  [priority_id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [File] (
	file_id integer NOT NULL,
	file_name varchar(256) NOT NULL,
	file_path varchar(256) NOT NULL,
	guid_name varchar(256) NOT NULL UNIQUE,
	attach_date datetime NOT NULL,
	task_id integer NOT NULL,
  CONSTRAINT [PK_FILE] PRIMARY KEY CLUSTERED
  (
  [file_id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [User] (
	user_id integer NOT NULL,
	user_name varchar(64) NOT NULL,
	user_lastname varchar(64) NOT NULL,
	user_login varchar(32) NOT NULL UNIQUE,
	user_password varchar(256) NOT NULL,
	email varchar(64) NOT NULL UNIQUE,
	country varchar(256),
	is_email_notified BIT DEFAULT '1',
	registration_date datetime NOT NULL,
	last_visit_date datetime NOT NULL,
  CONSTRAINT [PK_USER] PRIMARY KEY CLUSTERED
  (
  [user_id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Schedule] (
	schedule_id integer NOT NULL,
	start_term datetime,
	end_term datetime,
	is_every_day BIT DEFAULT '0',
	is_every_week BIT DEFAULT '0',
	is_every_month BIT DEFAULT '0',
	is_every_year BIT DEFAULT '0',
	is_reminder_on BIT DEFAULT '0',
	reminder_time datetime,
  CONSTRAINT [PK_SCHEDULE] PRIMARY KEY CLUSTERED
  (
  [schedule_id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [TaskList] (
	list_id integer NOT NULL,
	list_name varchar(64) NOT NULL,
	order_rank integer NOT NULL UNIQUE,
	color_r integer NOT NULL DEFAULT '255',
	color_g integer NOT NULL DEFAULT '255',
	color_b integer NOT NULL DEFAULT '255',
	user_id integer NOT NULL,
	filter_id integer NOT NULL,
  CONSTRAINT [PK_TASKLIST] PRIMARY KEY CLUSTERED
  (
  [list_id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Subtask] (
	subtask_id integer NOT NULL,
	subtask_name varchar(256) NOT NULL,
	order_in_list integer NOT NULL,
	is_completed BIT NOT NULL DEFAULT '0',
	task_id integer NOT NULL,
  CONSTRAINT [PK_SUBTASK] PRIMARY KEY CLUSTERED
  (
  [subtask_id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Doer] (
	doer_id integer NOT NULL,
	doer_name varchar(64) NOT NULL,
	user_id integer NOT NULL,
  CONSTRAINT [PK_DOER] PRIMARY KEY CLUSTERED
  (
  [doer_id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [ListFilter] (
	filter_id integer NOT NULL,
	is_show_completed binary NOT NULL DEFAULT '1',
	is_ordered_by_term BIT NOT NULL DEFAULT '0',
	is_ordered_by_prior BIT NOT NULL DEFAULT '0',
	is_ordered_by_tag BIT NOT NULL DEFAULT '0',
	selected_from_date date,
	selected_to_date date,
	selected_prior_id integer,
	selected_tag_id integer NOT NULL,
	is_only_favorites binary NOT NULL DEFAULT '0',
  CONSTRAINT [PK_LISTFILTER] PRIMARY KEY CLUSTERED
  (
  [filter_id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Tag] (
	tag_id integer NOT NULL,
	tag_name varchar(64) NOT NULL UNIQUE,
  CONSTRAINT [PK_TAG] PRIMARY KEY CLUSTERED
  (
  [tag_id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
ALTER TABLE [TaskItem] WITH CHECK ADD CONSTRAINT [TaskItem_fk0] FOREIGN KEY ([list_id]) REFERENCES [TaskList]([list_id])
ON UPDATE CASCADE
GO
ALTER TABLE [TaskItem] CHECK CONSTRAINT [TaskItem_fk0]
GO
ALTER TABLE [TaskItem] WITH CHECK ADD CONSTRAINT [TaskItem_fk1] FOREIGN KEY ([schedule_id]) REFERENCES [Schedule]([schedule_id])
ON UPDATE CASCADE
GO
ALTER TABLE [TaskItem] CHECK CONSTRAINT [TaskItem_fk1]
GO
ALTER TABLE [TaskItem] WITH CHECK ADD CONSTRAINT [TaskItem_fk2] FOREIGN KEY ([priority_id]) REFERENCES [Priority]([priority_id])
ON UPDATE CASCADE
GO
ALTER TABLE [TaskItem] CHECK CONSTRAINT [TaskItem_fk2]
GO
ALTER TABLE [TaskItem] WITH CHECK ADD CONSTRAINT [TaskItem_fk3] FOREIGN KEY ([tag_id]) REFERENCES [Tag]([tag_id])
ON UPDATE CASCADE
GO
ALTER TABLE [TaskItem] CHECK CONSTRAINT [TaskItem_fk3]
GO
ALTER TABLE [TaskItem] WITH CHECK ADD CONSTRAINT [TaskItem_fk4] FOREIGN KEY ([status_id]) REFERENCES [Status]([status_id])
ON UPDATE CASCADE
GO
ALTER TABLE [TaskItem] CHECK CONSTRAINT [TaskItem_fk4]
GO
ALTER TABLE [TaskItem] WITH CHECK ADD CONSTRAINT [TaskItem_fk5] FOREIGN KEY ([user_id]) REFERENCES [User]([user_id])
ON UPDATE CASCADE
GO
ALTER TABLE [TaskItem] CHECK CONSTRAINT [TaskItem_fk5]
GO
ALTER TABLE [TaskItem] WITH CHECK ADD CONSTRAINT [TaskItem_fk6] FOREIGN KEY ([doer_id]) REFERENCES [Doer]([doer_id])
ON UPDATE CASCADE
GO
ALTER TABLE [TaskItem] CHECK CONSTRAINT [TaskItem_fk6]
GO



ALTER TABLE [File] WITH CHECK ADD CONSTRAINT [File_fk0] FOREIGN KEY ([task_id]) REFERENCES [TaskItem]([task_id])
ON UPDATE CASCADE
GO
ALTER TABLE [File] CHECK CONSTRAINT [File_fk0]
GO



ALTER TABLE [TaskList] WITH CHECK ADD CONSTRAINT [TaskList_fk0] FOREIGN KEY ([user_id]) REFERENCES [User]([user_id])
ON UPDATE NO ACTION
GO
ALTER TABLE [TaskList] CHECK CONSTRAINT [TaskList_fk0]
GO
ALTER TABLE [TaskList] WITH CHECK ADD CONSTRAINT [TaskList_fk1] FOREIGN KEY ([filter_id]) REFERENCES [ListFilter]([filter_id])
ON UPDATE CASCADE
GO
ALTER TABLE [TaskList] CHECK CONSTRAINT [TaskList_fk1]
GO

ALTER TABLE [Subtask] WITH CHECK ADD CONSTRAINT [Subtask_fk0] FOREIGN KEY ([task_id]) REFERENCES [TaskItem]([task_id])
ON UPDATE CASCADE
GO
ALTER TABLE [Subtask] CHECK CONSTRAINT [Subtask_fk0]
GO

ALTER TABLE [Doer] WITH CHECK ADD CONSTRAINT [Doer_fk0] FOREIGN KEY ([user_id]) REFERENCES [User]([user_id])
ON UPDATE NO ACTION
GO
ALTER TABLE [Doer] CHECK CONSTRAINT [Doer_fk0]
GO

ALTER TABLE [ListFilter] WITH CHECK ADD CONSTRAINT [ListFilter_fk0] FOREIGN KEY ([selected_prior_id]) REFERENCES [Priority]([priority_id])
ON UPDATE NO ACTION
GO
ALTER TABLE [ListFilter] CHECK CONSTRAINT [ListFilter_fk0]
GO
ALTER TABLE [ListFilter] WITH CHECK ADD CONSTRAINT [ListFilter_fk1] FOREIGN KEY ([selected_tag_id]) REFERENCES [Tag]([tag_id])
ON UPDATE NO ACTION
GO
ALTER TABLE [ListFilter] CHECK CONSTRAINT [ListFilter_fk1]
GO


