CREATE OR REPLACE PACKAGE BODY PMP_CP0025
IS
-- 受注予定情報登録
PROCEDURE ENTRY
(
	-- 予定情報
	inF_REC_ORDER_SEQ_NO        IN PMT_APPOINTMENT.REC_ORDER_SEQ_NO%TYPE,        -- 受注管理番号
	inF_APPOINTMENT_ID          IN IX_A_APPOINTMENT_ID,        -- 予定ID
	inF_APPOINTMENT_TYPE        IN IX_A_APPOINTMENT_TYPE,        -- 予定種類
 	inF_APPOINTMENT_SUBJECT     IN IX_A_APPOINTMENT_SUBJECT,        -- 予定内容
	inF_APPOINTMENT_START       IN IX_A_APPOINTMENT_START,        -- 予定開始時間
	inF_APPOINTMENT_END         IN IX_A_APPOINTMENT_END,        -- 予定終了時間
	inF_APPOINTMENT_PROPERTIES  IN IX_A_APPOINTMENT_PROPERTIES,        -- 予定属性
	inF_APPOINTMENT_BODY        IN IX_A_APPOINTMENT_BODY,        -- 予定備考
	inF_DATA_DIV                IN IX_A_DATA_DIV,        -- データ区分
	inLAST_DEPT_CD		    IN PMT_ESTIMATE.LAST_DEPT_CD%TYPE,		-- 最終更新者部門CD_
	inLAST_USER_CD		    IN PMT_ESTIMATE.LAST_USER_CD%TYPE,		-- 最終更新者CD
	inAPPOINTMENT_COUNT	    IN  NUMBER,				        -- 予定件数
	outSQLCODE	            OUT NUMBER					-- SQLコード
)
IS
BEGIN
	----------------------
	--		通常登録	--
	----------------------

	-- 予定情報DELETE（複数件）
	DELETE FROM
		PMT_APPOINTMENT
	WHERE REC_ORDER_SEQ_NO = inF_REC_ORDER_SEQ_NO;  -- 受注管理番号


        IF inAPPOINTMENT_COUNT > 0 THEN  -- 対象件数有

		-- 見積折情報INSERT（複数件）
		FOR i IN 1..inAPPOINTMENT_COUNT LOOP

		INSERT INTO
			PMT_APPOINTMENT
		(
			REC_ORDER_SEQ_NO,               -- 受注管理番号
			APPOINTMENT_ID,                 -- 予定ID
			APPOINTMENT_TYPE,               -- 予定種類
			APPOINTMENT_SUBJECT,            -- 予定内容
			APPOINTMENT_START,              -- 予定開始時間
			APPOINTMENT_END,                -- 予定終了時間
			APPOINTMENT_PROPERTIES,         -- 予定属性
			APPOINTMENT_BODY,               -- 予定備考
			DATA_DIV,                       -- データ区分
			FIRST_DATE,			-- 初期登録日時
			FIRST_DEPT_CD,			-- 初期登録者部門CD
			FIRST_USER_CD,			-- 初期登録者CD
			LAST_DATE,			-- 最終更新日時
			LAST_DEPT_CD,			-- 最終更新者部門CD
			LAST_USER_CD			-- 最終更新者CD
		)
		VALUES
		(
			inF_REC_ORDER_SEQ_NO,	        -- 受注管理番号
			inF_APPOINTMENT_ID(i),          -- 予定ID
			inF_APPOINTMENT_TYPE(i),        -- 予定種類
			inF_APPOINTMENT_SUBJECT(i),     -- 予定内容
			inF_APPOINTMENT_START(i),       -- 予定開始時間
			inF_APPOINTMENT_END(i),         -- 予定終了時間
			inF_APPOINTMENT_PROPERTIES(i),  -- 予定属性
			inF_APPOINTMENT_BODY(i),        -- 予定備考
			'0',				-- データ区分
			SYSDATE,			-- 初期登録日時
			inLAST_DEPT_CD,			-- 初期登録者部門CD
			inLAST_USER_CD,			-- 初期登録者CD
			SYSDATE,			-- 最終更新日時
			inLAST_DEPT_CD,			-- 最終更新者部門CD
			inLAST_USER_CD			-- 最終更新者CD
		);

		END LOOP;

	END IF;

	-- 正常終了
	outSQLCODE := 0;

EXCEPTION

	WHEN OTHERS THEN
		outSQLCODE := SQLCODE;

END ENTRY;

END;
