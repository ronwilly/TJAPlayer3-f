using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Diagnostics;
using FDK;
using FDK.ExtensionMethods;

namespace TJAPlayer3
{
	/// <summary>
	/// 演奏画面の共通クラス (ドラム演奏画面, ギター演奏画面の継承元)
	/// </summary>
	internal abstract class CStage演奏画面共通 : CStage
	{
		// プロパティ

		// メソッド

		#region [ t演奏結果を格納する_ドラム() ]
		public void t演奏結果を格納する_ドラム( out CScoreIni.C演奏記録 Drums , int nPlayer)
		{
			Drums = new CScoreIni.C演奏記録();

			//if (  )
			{
				Drums.nスコア = (long) this.actScore.Get( nPlayer );
				Drums.dbゲーム型スキル値 = CScoreIni.tゲーム型スキルを計算して返す( TJAPlayer3.DTX[nPlayer].LEVELtaiko[TJAPlayer3.stage選曲.n確定された曲の難易度[0]], TJAPlayer3.DTX[nPlayer].n可視チップ数.Drums, this.nヒット数_Auto含まない[nPlayer].Perfect, this.actCombo.n現在のコンボ数.最高値[0]);
				Drums.db演奏型スキル値 = CScoreIni.t演奏型スキルを計算して返す( TJAPlayer3.DTX[nPlayer].n可視チップ数.Drums, this.nヒット数_Auto含まない[nPlayer].Perfect, this.nヒット数_Auto含まない[nPlayer].Great, this.nヒット数_Auto含まない[nPlayer].Good, this.nヒット数_Auto含まない[nPlayer].Poor, this.nヒット数_Auto含まない[nPlayer].Miss );
				Drums.nPerfect数 = TJAPlayer3.ConfigIni.b太鼓パートAutoPlay[nPlayer] ? this.nヒット数_Auto含む[nPlayer].Perfect : this.nヒット数_Auto含まない[nPlayer].Perfect;
				Drums.nGreat数 = TJAPlayer3.ConfigIni.b太鼓パートAutoPlay[nPlayer] ? this.nヒット数_Auto含む[nPlayer].Great : this.nヒット数_Auto含まない[nPlayer].Great;
				Drums.nGood数 = TJAPlayer3.ConfigIni.b太鼓パートAutoPlay[nPlayer] ? this.nヒット数_Auto含む[nPlayer].Good : this.nヒット数_Auto含まない[nPlayer].Good;
				Drums.nPoor数 = TJAPlayer3.ConfigIni.b太鼓パートAutoPlay[nPlayer] ? this.nヒット数_Auto含む[nPlayer].Poor : this.nヒット数_Auto含まない[nPlayer].Poor;
				Drums.nMiss数 = TJAPlayer3.ConfigIni.b太鼓パートAutoPlay[nPlayer] ? this.nヒット数_Auto含む[nPlayer].Miss : this.nヒット数_Auto含まない[nPlayer].Miss;
				Drums.nPerfect数_Auto含まない = this.nヒット数_Auto含まない[nPlayer].Perfect;
				Drums.nGreat数_Auto含まない = this.nヒット数_Auto含まない[nPlayer].Great;
				Drums.nGood数_Auto含まない = this.nヒット数_Auto含まない[nPlayer].Good;
				Drums.nPoor数_Auto含まない = this.nヒット数_Auto含まない[nPlayer].Poor;
				Drums.nMiss数_Auto含まない = this.nヒット数_Auto含まない[nPlayer].Miss;
				Drums.n連打数 = this.n合計連打数[ nPlayer ];
				Drums.n最大コンボ数 = this.actCombo.n現在のコンボ数.最高値[nPlayer];
				Drums.n全チップ数 = TJAPlayer3.DTX[0].n可視チップ数.Drums;
				Drums.bTight = TJAPlayer3.ConfigIni.bTight;
				Drums.eRandom = TJAPlayer3.ConfigIni.eRandom[0];
				//Drums.eInvisible = TJAPlayer3.ConfigIni.eInvisible;
				Drums.f譜面スクロール速度 = ( (float) ( TJAPlayer3.ConfigIni.n譜面スクロール速度[nPlayer] + 1 ) ) * 0.1f;
				Drums.n演奏速度分子 = TJAPlayer3.ConfigIni.n演奏速度;
				Drums.n演奏速度分母 = 20;
				Drums.bSTAGEFAILED有効 = TJAPlayer3.ConfigIni.bSTAGEFAILED有効;
				Drums.b演奏にキーボードを使用した = this.b演奏にキーボードを使った;
				Drums.b演奏にMIDI入力を使用した = this.b演奏にMIDI入力を使った;
				Drums.b演奏にジョイパッドを使用した = this.b演奏にジョイパッドを使った;
				Drums.b演奏にマウスを使用した = this.b演奏にマウスを使った;
				Drums.nPerfectになる範囲ms = TJAPlayer3.nPerfect範囲ms;
				Drums.nGreatになる範囲ms = TJAPlayer3.nGreat範囲ms;
				Drums.nGoodになる範囲ms = TJAPlayer3.nGood範囲ms;
				Drums.nPoorになる範囲ms = TJAPlayer3.nPoor範囲ms;
				Drums.strDTXManiaのバージョン = TJAPlayer3.VERSION;
				Drums.最終更新日時 = DateTime.Now.ToString();
				Drums.Hash = CScoreIni.t演奏セクションのMD5を求めて返す( Drums );
				Drums.fゲージ = (float)this.actGauge.db現在のゲージ値[ nPlayer ];
				Drums.b途中でAutoを切り替えたか = this.b途中でAutoを切り替えたか[nPlayer];
				if( !TJAPlayer3.ConfigIni.b太鼓パートAutoPlay[nPlayer] )
				{
					Drums.nハイスコア = TJAPlayer3.stage選曲.r確定されたスコア.譜面情報.nハイスコア; //2015.06.16 kairera0467 他難易度の上書き防止。
					Drums.nSecondScore = TJAPlayer3.stage選曲.r確定されたスコア.譜面情報.nSecondScore;
					Drums.nThirdScore = TJAPlayer3.stage選曲.r確定されたスコア.譜面情報.nThirdScore;
					Drums.strHiScorerName = TJAPlayer3.stage選曲.r確定されたスコア.譜面情報.strHiScorerName;
					Drums.strSecondScorerName = TJAPlayer3.stage選曲.r確定されたスコア.譜面情報.strSecondScorerName;
					Drums.strThirdScorerName = TJAPlayer3.stage選曲.r確定されたスコア.譜面情報.strThirdScorerName;

					if (TJAPlayer3.stage選曲.r確定されたスコア.譜面情報.nハイスコア[TJAPlayer3.stage選曲.n確定された曲の難易度[nPlayer]] < (int)this.actScore.Get(nPlayer))
					{
						Drums.nThirdScore[TJAPlayer3.stage選曲.n確定された曲の難易度[nPlayer]] = Drums.nSecondScore[TJAPlayer3.stage選曲.n確定された曲の難易度[nPlayer]];
						Drums.nSecondScore[TJAPlayer3.stage選曲.n確定された曲の難易度[nPlayer]] = Drums.nハイスコア[TJAPlayer3.stage選曲.n確定された曲の難易度[nPlayer]];
						Drums.nハイスコア[TJAPlayer3.stage選曲.n確定された曲の難易度[nPlayer]] = (int)this.actScore.Get(nPlayer);
						Drums.strThirdScorerName[TJAPlayer3.stage選曲.n確定された曲の難易度[nPlayer]] = Drums.strSecondScorerName[TJAPlayer3.stage選曲.n確定された曲の難易度[nPlayer]];
						Drums.strSecondScorerName[TJAPlayer3.stage選曲.n確定された曲の難易度[nPlayer]] = Drums.strHiScorerName[TJAPlayer3.stage選曲.n確定された曲の難易度[nPlayer]];
						Drums.strHiScorerName[TJAPlayer3.stage選曲.n確定された曲の難易度[nPlayer]] = TJAPlayer3.ConfigIni.strPlayerName[nPlayer];
					}
					else if (TJAPlayer3.stage選曲.r確定されたスコア.譜面情報.nSecondScore[TJAPlayer3.stage選曲.n確定された曲の難易度[nPlayer]] < (int)this.actScore.Get(nPlayer)) 
					{
						Drums.nThirdScore[TJAPlayer3.stage選曲.n確定された曲の難易度[nPlayer]] = Drums.nSecondScore[TJAPlayer3.stage選曲.n確定された曲の難易度[nPlayer]];
						Drums.nSecondScore[TJAPlayer3.stage選曲.n確定された曲の難易度[nPlayer]] = (int)this.actScore.Get(nPlayer);
						Drums.strThirdScorerName[TJAPlayer3.stage選曲.n確定された曲の難易度[nPlayer]] = Drums.strSecondScorerName[TJAPlayer3.stage選曲.n確定された曲の難易度[nPlayer]];
						Drums.strSecondScorerName[TJAPlayer3.stage選曲.n確定された曲の難易度[nPlayer]] = TJAPlayer3.ConfigIni.strPlayerName[nPlayer];
					}
					else if (TJAPlayer3.stage選曲.r確定されたスコア.譜面情報.nThirdScore[TJAPlayer3.stage選曲.n確定された曲の難易度[nPlayer]] < (int)this.actScore.Get(nPlayer))
					{
						Drums.strThirdScorerName[TJAPlayer3.stage選曲.n確定された曲の難易度[nPlayer]] = TJAPlayer3.ConfigIni.strPlayerName[nPlayer];
						Drums.nThirdScore[TJAPlayer3.stage選曲.n確定された曲の難易度[nPlayer]] = (int)this.actScore.Get(nPlayer);
					}

					var danC = TJAPlayer3.stage演奏ドラム画面.actDan.GetExam();
					for (int i = 0; i < danC.Length; i++)
					{
						Drums.Dan_C[i] = danC[i];
					}

					Drums.n王冠 = TJAPlayer3.stage選曲.r確定されたスコア.譜面情報.n王冠;

					if (TJAPlayer3.stage選曲.n確定された曲の難易度[nPlayer] != (int)Difficulty.Dan)
					{
						if (Drums.fゲージ < 80)
						{
							if (TJAPlayer3.stage選曲.r確定されたスコア.譜面情報.n王冠[TJAPlayer3.stage選曲.n確定された曲の難易度[nPlayer]] < 0)
								Drums.n王冠[TJAPlayer3.stage選曲.n確定された曲の難易度[nPlayer]] = 0;
						}
						else if (Drums.nMiss数_Auto含まない != 0)
						{
							if (TJAPlayer3.stage選曲.r確定されたスコア.譜面情報.n王冠[TJAPlayer3.stage選曲.n確定された曲の難易度[nPlayer]] < 1)
								Drums.n王冠[TJAPlayer3.stage選曲.n確定された曲の難易度[nPlayer]] = 1;
						}
						else if (Drums.nGreat数_Auto含まない != 0)
						{
							if (TJAPlayer3.stage選曲.r確定されたスコア.譜面情報.n王冠[TJAPlayer3.stage選曲.n確定された曲の難易度[nPlayer]] < 2)
								Drums.n王冠[TJAPlayer3.stage選曲.n確定された曲の難易度[nPlayer]] = 2;
						}
						else
						{
							if (TJAPlayer3.stage選曲.r確定されたスコア.譜面情報.n王冠[TJAPlayer3.stage選曲.n確定された曲の難易度[nPlayer]] < 3)
								Drums.n王冠[TJAPlayer3.stage選曲.n確定された曲の難易度[nPlayer]] = 3;
						}
					}
					else {
						switch (TJAPlayer3.stage演奏ドラム画面.actDan.GetExamStatus(Drums.Dan_C))
						{
							case Exam.Status.Failure:
								if (TJAPlayer3.stage選曲.r確定されたスコア.譜面情報.n王冠[TJAPlayer3.stage選曲.n確定された曲の難易度[nPlayer]] < 0)
									Drums.n王冠[TJAPlayer3.stage選曲.n確定された曲の難易度[nPlayer]] = 0;
								break;
							case Exam.Status.Success:
								if (TJAPlayer3.stage選曲.r確定されたスコア.譜面情報.n王冠[TJAPlayer3.stage選曲.n確定された曲の難易度[nPlayer]] < 1)
									Drums.n王冠[TJAPlayer3.stage選曲.n確定された曲の難易度[nPlayer]] = 1;
								break;
							case Exam.Status.Better_Success:
								if (TJAPlayer3.stage選曲.r確定されたスコア.譜面情報.n王冠[TJAPlayer3.stage選曲.n確定された曲の難易度[nPlayer]] < 2)
									Drums.n王冠[TJAPlayer3.stage選曲.n確定された曲の難易度[nPlayer]] = 2;
								break;
							default:
								if (TJAPlayer3.stage選曲.r確定されたスコア.譜面情報.n王冠[TJAPlayer3.stage選曲.n確定された曲の難易度[nPlayer]] < 0)
									Drums.n王冠[TJAPlayer3.stage選曲.n確定された曲の難易度[nPlayer]] = 0;
								break;
						}
					}

				}
			}
		}
		#endregion

		// CStage 実装

		public override void On活性化()
		{
			listChip = new List<CDTX.CChip>[ 4 ];
			for( int i = 0; i < TJAPlayer3.ConfigIni.nPlayerCount; i++ )
			{
				listChip[i] = TJAPlayer3.DTX[i].listChip;

				int n整数値管理 = 0;
				if (r指定時刻に一番近い未ヒットChipを過去方向優先で検索する(0, i) != null)//2020.07.08 Mr-Ojii 未ヒットチップがないときの例外の発生回避
				{
					foreach (CDTX.CChip chip in listChip[i])
					{
						if ((chip.nチャンネル番号 == 0x15 || chip.nチャンネル番号 == 0x16) && (n整数値管理 < this.listChip[i].Count - 1))
						{

							if (chip.db発声時刻ms < r指定時刻に一番近い未ヒットChipを過去方向優先で検索する(0, i).db発声時刻ms)
							{
								chip.n描画優先度 = 1;
							}
						}
						n整数値管理++;
					}
				}
			}

			for (int index = TJAPlayer3.DTX[0].listChip.Count - 1; index >= 0; index--)
			{
				if (TJAPlayer3.DTX[0].listChip[index].nチャンネル番号 == 0x01)
				{
					this.bgmlength = TJAPlayer3.DTX[0].listChip[index].GetDuration() + TJAPlayer3.DTX[0].listChip[index].n発声時刻ms;
					break;
				}
			}

			ctChipAnime = new CCounter[2];
			ctChipAnimeLag = new CCounter[2];
			for (int i = 0; i < 2; i++)
			{
				ctChipAnime[i] = new CCounter();
				ctChipAnimeLag[i] = new CCounter();
			}

			listWAV = TJAPlayer3.DTX[0].listWAV;

			this.eフェードアウト完了時の戻り値 = E演奏画面の戻り値.継続;
			this.n現在のトップChip = ( listChip[0].Count > 0 ) ? 0 : -1;
			this.L最後に再生したHHの実WAV番号 = new List<int>( 16 );
			this.n最後に再生したHHのチャンネル番号 = 0;
			for ( int i = 0; i < 50; i++ )
			{
				this.n最後に再生したBGMの実WAV番号[ i ] = -1;
			}

			this.nヒット数_Auto含まない[0] = new CHITCOUNTOFRANK();
			this.nヒット数_Auto含まない[1] = new CHITCOUNTOFRANK();
			this.nヒット数_Auto含む[0] = new CHITCOUNTOFRANK();
			this.nヒット数_Auto含む[1] = new CHITCOUNTOFRANK();

			this.b演奏にキーボードを使った = false;
			this.b演奏にジョイパッドを使った = false;
			this.b演奏にMIDI入力を使った = false;
			this.b演奏にマウスを使った = false;

			base.On活性化();
			this.tパネル文字列の設定();
			//this.演奏判定ライン座標();
			this.bIsGOGOTIME = new bool[]{ false, false, false, false };
			this.bUseBranch = new bool[]{ false, false, false, false };
			this.n現在のコース = new int[ 4 ];
			this.n次回のコース = new int[ 4 ];
			this.nレーン用表示コース = new int[4];
			for (int i = 0; i < 2; i++)
			{
				this.b強制的に分岐させた[i] = false;

				TJAPlayer3.stage演奏ドラム画面.actMtaiko.After[i] = 0;
				TJAPlayer3.stage演奏ドラム画面.actLaneTaiko.stBranch[i].nAfter = 0;
				TJAPlayer3.stage演奏ドラム画面.actMtaiko.Before[i] = 0;
				TJAPlayer3.stage演奏ドラム画面.actLaneTaiko.stBranch[i].nBefore = 0;
			}
			for (int i = 0; i < CBranchScore.Length; i++)
			{
				this.CBranchScore[i] = new CBRANCHSCORE();

				//大音符分岐時の情報をまとめるため
				this.CBranchScore[i].cBigNotes = new CBRANCHSCORE();
			}
			this.b連打中 = new bool[]{ false, false, false, false };
			this.n現在の連打数 = new int[]{ 0, 0, 0, 0 };
			this.n合計連打数 = new int[]{ 0, 0, 0, 0 };
			this.n分岐した回数 = new int[ 4 ];
			for (int i = 0; i < 2; i++)
			{
				ShownLyric[i] = 0;
			}
			this.nJPOSSCROLL = new int[ 4 ];
			this.bLEVELHOLD = new bool[]{ false, false, false, false };

			this.bDoublePlay = TJAPlayer3.ConfigIni.nPlayerCount >= 2 ? true : false;

			this.nLoopCount_Clear = 1;

			this.tBranchReset(-1);
						
//			this.nRisky = CDTXMania.ConfigIni.nRisky;											// #23559 2011.7.28 yyagi
			actGauge.Init( TJAPlayer3.ConfigIni.nRisky );									// #23559 2011.7.28 yyagi
			this.nPolyphonicSounds = TJAPlayer3.ConfigIni.nPoliphonicSounds;
			e判定表示優先度 = TJAPlayer3.ConfigIni.e判定表示優先度;

			TJAPlayer3.Skin.tRemoveMixerAll();	// 効果音のストリームをミキサーから解除しておく

			queueMixerSound = new Queue<stmixer>( 64 );
			bIsOpenAL = ( TJAPlayer3.Sound管理.GetCurrentSoundDeviceType() == "OpenAL" );
			bUseOSTimer = TJAPlayer3.ConfigIni.bUseOSTimer;
			this.bPAUSE = false;
			
			db再生速度 = ( (double) TJAPlayer3.ConfigIni.n演奏速度 ) / 20.0;
			
			#region [ 演奏開始前にmixer登録しておくべきサウンド(開幕してすぐに鳴らすことになるチップ音)を登録しておく ]
			foreach ( CDTX.CChip pChip in listChip[0] )
			{
//				Debug.WriteLine( "CH=" + pChip.nチャンネル番号.ToString( "x2" ) + ", 整数値=" + pChip.n整数値 +  ", time=" + pChip.n発声時刻ms );
				if ( pChip.n発声時刻ms <= 0 )
				{
					if ( pChip.nチャンネル番号 == 0xDA )
					{
						pChip.bHit = true;
//						Trace.TraceInformation( "first [DA] BAR=" + pChip.n発声位置 / 384 + " ch=" + pChip.nチャンネル番号.ToString( "x2" ) + ", wav=" + pChip.n整数値 + ", time=" + pChip.n発声時刻ms );
						if ( listWAV.TryGetValue( pChip.n整数値_内部番号, out CDTX.CWAV wc ) )
						{
							for ( int i = 0; i < nPolyphonicSounds; i++ )
							{
								if ( wc.rSound[ i ] != null )
								{
									TJAPlayer3.Sound管理.AddMixer( wc.rSound[ i ], db再生速度, pChip.b演奏終了後も再生が続くチップである );
									//AddMixer( wc.rSound[ i ] );		// 最初はqueueを介さず直接ミキサー登録する
								}
							}
						}
					}
				}
				else
				{
					break;
				}
			}
			#endregion

			this.sw = new Stopwatch();
			//          this.sw2 = new Stopwatch();
			//			this.gclatencymode = GCSettings.LatencyMode;
			//			GCSettings.LatencyMode = GCLatencyMode.Batch;	// 演奏画面中はGCを抑止する
			this.bIsAlreadyCleared = new bool[2];
			this.bIsAlreadyMaxed = new bool[2];

			this.ListDan_Number = 0;
			this.IsDanFailed = false;
			this.b途中でAutoを切り替えたか = new bool[] { false, false };
		}
		public override void On非活性化()
		{
			this.bgmlength = 1;
			this.L最後に再生したHHの実WAV番号.Clear();	// #23921 2011.1.4 yyagi
			this.L最後に再生したHHの実WAV番号 = null;	//

			for (int i = 0; i < 2; i++)
			{
				ctChipAnime[i] = null;
				ctChipAnimeLag[i] = null;
			}

			listWAV.Clear();
			listWAV = null;
			listChip = null;
			queueMixerSound.Clear();
			queueMixerSound = null;
//			GCSettings.LatencyMode = this.gclatencymode;

			var meanLag = CLagLogger.LogAndReturnMeanLag();

			if (TJAPlayer3.IsPerformingCalibration && meanLag != null)
			{
				var oldInputAdjustTimeMs = TJAPlayer3.ConfigIni.nInputAdjustTimeMs;
				var newInputAdjustTimeMs = oldInputAdjustTimeMs - (int) Math.Round(meanLag.Value);
				Trace.TraceInformation($"Calibration complete. Updating InputAdjustTime from {oldInputAdjustTimeMs}ms to {newInputAdjustTimeMs}ms.");
				TJAPlayer3.ConfigIni.nInputAdjustTimeMs = newInputAdjustTimeMs;
			}

			this.actDan.IsAnimating = false;//2020.07.03 Mr-Ojii IsAnimating=trueのときにそのまま選曲画面に戻ると、文字列が描画されない問題修正用。

			base.On非活性化();
		}
		public override void OnManagedリソースの作成()
		{
			if ( !base.b活性化してない )
			{
				this.t背景テクスチャの生成();
				base.OnManagedリソースの作成();
			}
		}
		public override void OnManagedリソースの解放()
		{
			if ( !base.b活性化してない )
			{
				TJAPlayer3.t安全にDisposeする( ref this.tx背景 );
				Trace.TraceInformation("CStage演奏画面共通 リソースの開放");
				base.OnManagedリソースの解放();
			}
		}

		// その他

		#region [ protected ]
		//-----------------
		public class CHITCOUNTOFRANK
		{
			// Fields
			public int Good;
			public int Great;
			public int Miss;
			public int Perfect;
			public int Poor;

			// Properties
			public int this[ int index ]
			{
				get
				{
					switch ( index )
					{
						case 0:
							return this.Perfect;

						case 1:
							return this.Great;

						case 2:
							return this.Good;

						case 3:
							return this.Poor;

						case 4:
							return this.Miss;
					}
					throw new IndexOutOfRangeException();
				}
				set
				{
					switch ( index )
					{
						case 0:
							this.Perfect = value;
							return;

						case 1:
							this.Great = value;
							return;

						case 2:
							this.Good = value;
							return;

						case 3:
							this.Poor = value;
							return;

						case 4:
							this.Miss = value;
							return;
					}
					throw new IndexOutOfRangeException();
				}
			}
		}

		protected struct stmixer
		{
			internal bool bIsAdd;
			internal CSound csound;
			internal bool b演奏終了後も再生が続くチップである;
		};

		/// <summary>
		/// 分岐用のスコアをまとめるクラス。
		/// .2020.04.21.akasoko26
		/// </summary>
		public class CBRANCHSCORE//2020.04.25 Mr-Ojii akasoko26さんのコードをもとに追加
		{
			public CBRANCHSCORE cBigNotes;//大音符分岐時の情報をまとめるため
			public int nRoll;
			public int nGreat;
			public int nGood;
			public int nMiss;
			public int nScore;
		}

		public CAct演奏AVI actAVI;
		public Rainbow Rainbow;
		public CAct演奏Combo共通 actCombo;
		//protected CActFIFOBlack actFI;
		protected CActFIFOStart actFI;
		protected CActFIFOBlack actFO;
		protected CActFIFOResult actFOClear;
		public    CAct演奏ゲージ共通 actGauge;

		public CAct演奏DrumsDancer actDancer;
		protected CAct演奏判定文字列共通 actJudgeString;
		public TaikoLaneFlash actTaikoLaneFlash;
		public CAct演奏パネル文字列 actPanel;
		public CAct演奏演奏情報 actPlayInfo;
		public CAct演奏スコア共通 actScore;
		public CAct演奏ステージ失敗 actStageFailed;
		protected CAct演奏スクロール速度 act譜面スクロール速度;
		protected CAct演奏Drums連打 actRoll;
		protected CAct演奏Drums風船 actBalloon;
		public CAct演奏Drumsキャラクター actChara;
		protected CAct演奏Drums連打キャラ actRollChara;
		protected CAct演奏Drumsコンボ吹き出し actComboBalloon;
		protected CAct演奏Combo音声 actComboVoice;
		protected CAct演奏PauseMenu actPauseMenu;
		public CAct演奏Drumsチップエフェクト actChipEffects;
		public CAct演奏DrumsRunner actRunner;
		public CAct演奏DrumsMob actMob;
		public Dan_Cert actDan;
		public bool bPAUSE;
		public bool[] bIsAlreadyCleared;
		public bool[] bIsAlreadyMaxed;
		protected bool b演奏にMIDI入力を使った;
		protected bool b演奏にキーボードを使った;
		protected bool b演奏にジョイパッドを使った;
		protected bool b演奏にマウスを使った;
		public CCounter[] ctChipAnime;
		public CCounter[] ctChipAnimeLag;
		private int bgmlength = 1;
		private bool[] b途中でAutoを切り替えたか;

		protected E演奏画面の戻り値 eフェードアウト完了時の戻り値;
		protected readonly int[] nチャンネル0Atoパッド08 = new int[] { 1, 2, 3, 4, 5, 7, 6, 1, 8, 0, 9, 9 };
		protected readonly int[] nチャンネル0Atoレーン07 = new int[] { 1, 2, 3, 4, 5, 7, 6, 1, 9, 0, 8, 8 };
																	//                         RD LC  LP  RD
		protected readonly int[] nパッド0Atoチャンネル0A = new int[] { 0x11, 0x12, 0x13, 0x14, 0x15, 0x17, 0x16, 0x18, 0x19, 0x1a, 0x1b, 0x1c };
		protected readonly int[] nパッド0Atoパッド08 = new int[] { 1, 2, 3, 4, 5, 6, 7, 1, 8, 0, 9, 9 };// パッド画像のヒット処理用
															  //   HH SD BD HT LT FT CY HHO RD LC LP LBD
		protected readonly int[] nパッド0Atoレーン07 = new int[] { 1, 2, 3, 4, 5, 6, 7, 1, 9, 0, 8, 8 };
		public CHITCOUNTOFRANK[] nヒット数_Auto含まない = new CHITCOUNTOFRANK[2];
		public CHITCOUNTOFRANK[] nヒット数_Auto含む = new CHITCOUNTOFRANK[2];
		public int n現在のトップChip = -1;
		protected int[] n最後に再生したBGMの実WAV番号 = new int[ 50 ];
		protected int n最後に再生したHHのチャンネル番号;
		protected List<int> L最後に再生したHHの実WAV番号;		// #23921 2011.1.4 yyagi: change "int" to "List<int>", for recording multiple wav No.

		protected volatile Queue<stmixer> queueMixerSound;		// #24820 2013.1.21 yyagi まずは単純にAdd/Removeを1個のキューでまとめて管理するやり方で設計する
		protected DateTime dtLastQueueOperation;				//
		protected bool bIsOpenAL;							//
		protected double db再生速度;

		protected CTexture tx背景;

//		protected int nRisky_InitialVar, nRiskyTime;		// #23559 2011.7.28 yyagi → CAct演奏ゲージ共通クラスに隠蔽
		protected int nPolyphonicSounds;
		protected List<CDTX.CChip>[] listChip = new List<CDTX.CChip>[4];
		protected Dictionary<int, CDTX.CWAV> listWAV;
		protected bool bUseOSTimer;
		protected E判定表示優先度 e判定表示優先度;

		public CBRANCHSCORE[] CBranchScore = new CBRANCHSCORE[6];
		public bool[] bIsGOGOTIME = new bool[ 4 ];
		public bool[] bUseBranch = new bool[ 4 ];
		public int[] n現在のコース = new int[ 4 ]; //0:普通譜面 1:玄人譜面 2:達人譜面
		public int[] n次回のコース = new int[ 4 ];
		public int[] nレーン用表示コース = new int[4];
		protected bool[] b譜面分岐中 = new bool[] { false, false, false, false };
		protected int[] n分岐した回数 = new int[ 4 ];
		protected int[] nJPOSSCROLL = new int[ 4 ];

		public bool[] b強制的に分岐させた = new bool[] { false, false, false, false };
		public bool[] bLEVELHOLD = new bool[] { false, false, false, false };

		private readonly int[] ShownLyric = new int[] { 0, 0 };
		public bool[] b連打中 = new bool[]{ false, false, false, false }; //奥の手
		private int[] n合計連打数 = new int[ 4 ];
		protected int[] n風船残り = new int[ 4 ];
		protected int[] n現在の連打数 = new int[ 4 ];
		protected E連打State eRollState;

		protected int nWaitButton;
		

		public CDTX.CChip[] chip現在処理中の連打チップ = new CDTX.CChip[ 4 ];

		protected const int NOTE_GAP = 25;
		
		public int nLoopCount_Clear;
		protected int[,] nScore = new int[2, 11];

		protected int[] nHand = new int[4];

		protected CSound[] soundRed = new CSound[2];
		protected CSound[] soundBlue = new CSound[2];
		protected CSound[] soundAdlib = new CSound[2];



		public bool bDoublePlay; // 2016.08.21 kairera0467 表示だけ。

		protected Stopwatch sw;     // 2011.6.13 最適化検討用のストップウォッチ
									//		protected Stopwatch sw2;
									//		protected GCLatencyMode gclatencymode;


		private bool[] b強制分岐譜面 = new bool[4];
		public double nBranch条件数値A;
		public double nBranch条件数値B;
		private int ListDan_Number;
		private bool IsDanFailed;
		private readonly int[] NowProcessingChip = new int[] { 0, 0 };


		public void AddMixer( CSound cs, bool _b演奏終了後も再生が続くチップである )
		{
			stmixer stm = new stmixer()
			{
				bIsAdd = true,
				csound = cs,
				b演奏終了後も再生が続くチップである = _b演奏終了後も再生が続くチップである
			};
			queueMixerSound.Enqueue( stm );
//		Debug.WriteLine( "★Queue: add " + Path.GetFileName( stm.csound.strファイル名 ));
		}
		public void RemoveMixer( CSound cs )
		{
			stmixer stm = new stmixer()
			{
				bIsAdd = false,
				csound = cs,
				b演奏終了後も再生が続くチップである = false
			};
			queueMixerSound.Enqueue( stm );
//		Debug.WriteLine( "★Queue: remove " + Path.GetFileName( stm.csound.strファイル名 ));
		}
		public void ManageMixerQueue()
		{
			// もしサウンドの登録/削除が必要なら、実行する
			if ( queueMixerSound.Count > 0 )
			{
				//Debug.WriteLine( "☆queueLength=" + queueMixerSound.Count );
				DateTime dtnow = DateTime.Now;
				TimeSpan ts = dtnow - dtLastQueueOperation;
				if ( ts.Milliseconds > 7 )
				{
					for ( int i = 0; i < 2 && queueMixerSound.Count > 0; i++ )
					{
						dtLastQueueOperation = dtnow;
						stmixer stm = queueMixerSound.Dequeue();
						if ( stm.bIsAdd )
						{
							TJAPlayer3.Sound管理.AddMixer( stm.csound, db再生速度, stm.b演奏終了後も再生が続くチップである );
						}
						else
						{
							TJAPlayer3.Sound管理.RemoveMixer( stm.csound );
						}
					}
				}
			}
		}

		internal E判定 e指定時刻からChipのJUDGEを返す(long nTime, CDTX.CChip pChip)
		{
			var e判定 = e指定時刻からChipのJUDGEを返すImpl(nTime, pChip);

			// When performing calibration, reduce audio distraction from user input.
			// For users who play primarily by watching notes cross the judgment position,
			// you might think that we want them to see visual judgment feedback during
			// calibration, but we do not. Humans are remarkably good at adjusting
			// the timing of their own physical movement, even without realizing it.
			// We are calibrating their input timing for the purposes of judgment.
			// We do not want them subconsciously playing early so as to line up
			// their hits with the perfect, good, etc. judgment results based on their
			// current (and soon to be replaced) input adjust time values.
			// Instead, we want them focused on the sounds of their keyboard, tatacon,
			// other controller, etc. and the visuals of notes crossing the judgment position.
			if (TJAPlayer3.IsPerformingCalibration)
			{
				return e判定 < E判定.Good ? E判定.Good : e判定;
			}
			else
			{
				return e判定;
			}
		}

		private E判定 e指定時刻からChipのJUDGEを返すImpl( long nTime, CDTX.CChip pChip )
		{
			if ( pChip != null )
			{
				pChip.nLag = (int) ( nTime - pChip.n発声時刻ms );		// #23580 2011.1.3 yyagi: add "nInputAdjustTime" to add input timing adjust feature
				int nDeltaTime = Math.Abs( pChip.nLag );
				//Debug.WriteLine("nAbsTime=" + (nTime - pChip.n発声時刻ms) + ", nDeltaTime=" + (nTime + nInputAdjustTime - pChip.n発声時刻ms));
				if( pChip.nチャンネル番号 == 0x15 || pChip.nチャンネル番号 == 0x16 )
				{
					if ((CSound管理.rc演奏用タイマ.n現在時刻ms * (((double)TJAPlayer3.ConfigIni.n演奏速度) / 20.0)) > pChip.n発声時刻ms && (CSound管理.rc演奏用タイマ.n現在時刻ms * (((double)TJAPlayer3.ConfigIni.n演奏速度) / 20.0)) < pChip.nノーツ終了時刻ms)
					{
						return E判定.Perfect;
					}
				}
				else if( pChip.nチャンネル番号 == 0x17 )
				{
					if ((CSound管理.rc演奏用タイマ.n現在時刻ms * (((double)TJAPlayer3.ConfigIni.n演奏速度) / 20.0)) >= pChip.n発声時刻ms - 17 && (CSound管理.rc演奏用タイマ.n現在時刻ms * (((double)TJAPlayer3.ConfigIni.n演奏速度) / 20.0)) < pChip.nノーツ終了時刻ms)
					{
						return E判定.Perfect;
					}
				}
				if ( nDeltaTime <= TJAPlayer3.nPerfect範囲ms * (((double)TJAPlayer3.ConfigIni.n演奏速度) / 20.0))
				{
					return E判定.Perfect;
				}
				if ( nDeltaTime <= TJAPlayer3.nGood範囲ms * (((double)TJAPlayer3.ConfigIni.n演奏速度) / 20.0))
				{
					if( TJAPlayer3.ConfigIni.bJust )
						return E判定.Poor;
					return E判定.Good;
				}
				if ( nDeltaTime <= TJAPlayer3.nPoor範囲ms * (((double)TJAPlayer3.ConfigIni.n演奏速度) / 20.0))
				{
					return E判定.Poor;
				}
			}
			return E判定.Miss;
		}

		protected CDTX.CChip r指定時刻に一番近い連打Chip_ヒット未済問わず不可視考慮( long nTime, int nChannel, int nInputAdjustTime, int nPlayer )
		{
			//sw2.Start();
//Trace.TraceInformation( "NTime={0}, nChannel={1:x2}", nTime, nChannel );
			nTime += nInputAdjustTime;						// #24239 2011.1.23 yyagi InputAdjust

			int nIndex_InitialPositionSearchingToPast;
			if ( this.n現在のトップChip == -1 )				// 演奏データとして1個もチップがない場合は
			{
				//sw2.Stop();
				return null;
			}

			List<CDTX.CChip> playerListChip = listChip[ nPlayer ];
			int count = playerListChip.Count;
			int nIndex_NearestChip_Future = nIndex_InitialPositionSearchingToPast = this.n現在のトップChip;
			if ( this.n現在のトップChip >= count )			// その時点で演奏すべきチップが既に全部無くなっていたら
			{
				nIndex_NearestChip_Future = nIndex_InitialPositionSearchingToPast = count - 1;
			}
			//int nIndex_NearestChip_Future;	// = nIndex_InitialPositionSearchingToFuture;
			//while ( nIndex_NearestChip_Future < count )		// 未来方向への検索
			for ( ; nIndex_NearestChip_Future < count; nIndex_NearestChip_Future++)
			{
				if ( ( ( 0x11 <= nChannel ) && ( nChannel <= 0x17 ) ) )
				{
					CDTX.CChip chip = playerListChip[ nIndex_NearestChip_Future ];

					if ( chip.nチャンネル番号 == nChannel )
					{
						if ( chip.n発声時刻ms > nTime )
						{
							break;
						}
						if( chip.nコース != this.n次回のコース[ nPlayer ] )
						{
							break;
						}
						nIndex_InitialPositionSearchingToPast = nIndex_NearestChip_Future;
					}
					continue;	// ほんの僅かながら高速化
				}

				// nIndex_NearestChip_Future++;
			}
			int nIndex_NearestChip_Past = nIndex_InitialPositionSearchingToPast;
			//while ( nIndex_NearestChip_Past >= 0 )			// 過去方向への検索
			for ( ; nIndex_NearestChip_Past >= 0; nIndex_NearestChip_Past-- )
			{
				if ( ( 0x15 <= nChannel ) && ( nChannel <= 0x17 ) )
				{
					CDTX.CChip chip = playerListChip[ nIndex_NearestChip_Past ];

					if ( ( ( chip.nチャンネル番号 == nChannel ) )  )
					{
						break;
					}
				}
				// nIndex_NearestChip_Past--;
			}

			if ( nIndex_NearestChip_Future >= count )
			{
				if ( nIndex_NearestChip_Past < 0 )	// 検索対象が過去未来どちらにも見つからなかった場合
				{
					return null;
				}
				else 								// 検索対象が未来方向には見つからなかった(しかし過去方向には見つかった)場合
				{
					//sw2.Stop();
					return playerListChip[ nIndex_NearestChip_Past ];
				}
			}
			else if ( nIndex_NearestChip_Past < 0 )	// 検索対象が過去方向には見つからなかった(しかし未来方向には見つかった)場合
			{
				//sw2.Stop();
				return playerListChip[ nIndex_NearestChip_Future ];
			}
													// 検索対象が過去未来の双方に見つかったなら、より近い方を採用する
			CDTX.CChip nearestChip_Future = playerListChip[ nIndex_NearestChip_Future ];
			CDTX.CChip nearestChip_Past   = playerListChip[ nIndex_NearestChip_Past ];
			int nDiffTime_Future = Math.Abs( (int) ( nTime - nearestChip_Future.n発声時刻ms ) );
			int nDiffTime_Past   = Math.Abs( (int) ( nTime - nearestChip_Past.n発声時刻ms ) );
			if ( nDiffTime_Future >= nDiffTime_Past )
			{
				//sw2.Stop();
				return nearestChip_Past;
			}
			//sw2.Stop();
			return nearestChip_Future;
		}
		protected void tサウンド再生( CDTX.CChip pChip, int nPlayer )
		{
			int index = pChip.nチャンネル番号;
			if (index == 0x11 || index == 0x13 || index == 0x1A)
			{
				this.soundRed[pChip.nPlayerSide]?.t再生を開始する();
			}
			else if (index == 0x12 || index == 0x14 || index == 0x1B)
			{
				this.soundBlue[pChip.nPlayerSide]?.t再生を開始する();
			}
			else if (index == 0x1F)
			{
				this.soundAdlib[pChip.nPlayerSide]?.t再生を開始する();
			}

			if ( this.nHand[ nPlayer ] == 0 )
				this.nHand[ nPlayer ]++;
			else
				this.nHand[ nPlayer ] = 0;
		}

		protected bool tRollProcess( CDTX.CChip pChip, double dbProcess_time, int num, int sort, int Input, int nPlayer )
		{
			if ( dbProcess_time >= pChip.n発声時刻ms && dbProcess_time < pChip.nノーツ終了時刻ms )
			{
				if( pChip.nRollCount == 0 )
				{
					this.actRoll.b表示[ nPlayer ] = true;
					this.n現在の連打数[ nPlayer ] = 0;
					this.actRoll.t枠表示時間延長( nPlayer );
				}
				this.actRoll.t枠表示時間延長(nPlayer);
				this.b連打中[ nPlayer ] = true;
				if(this.actRoll.ct連打アニメ[nPlayer].b終了値に達してない)
				{
					this.actRoll.ct連打アニメ[nPlayer] = new CCounter(0, 9, 14, TJAPlayer3.Timer);
					this.actRoll.ct連打アニメ[nPlayer].n現在の値 = 1;
				}
				else
				{
					this.actRoll.ct連打アニメ[nPlayer] = new CCounter(0, 9, 14, TJAPlayer3.Timer);
				}


				pChip.RollEffectLevel += 10;
				if(pChip.RollEffectLevel >= 100)
				{
					pChip.RollEffectLevel = 100;
					pChip.RollInputTime = new CCounter(0, 1500, 1, TJAPlayer3.Timer);
					pChip.RollDelay?.t停止();
				} else
				{
					pChip.RollInputTime = new CCounter(0, 150, 1, TJAPlayer3.Timer);
					pChip.RollDelay?.t停止(); 
				}

				if ( pChip.nチャンネル番号 == 0x15 )
					this.eRollState = E連打State.roll;
				else
					this.eRollState = E連打State.rollB;

				pChip.nRollCount++;
				
				this.n現在の連打数[ nPlayer ]++;
				this.CBranchScore[nPlayer].nRoll++;
				this.n合計連打数[ nPlayer ]++;
				if(TJAPlayer3.stage選曲.n確定された曲の難易度[0] != (int)Difficulty.Dan) this.actRollChara.Start(nPlayer);

				float mag;
				//2017.01.28 DD CDTXから直接呼び出す
				if (pChip.bGOGOTIME && !TJAPlayer3.ConfigIni.ShinuchiMode[nPlayer]) //2018.03.11 kairera0467 チップに埋め込んだフラグから読み取る
					mag = 1.2f;
				else
					mag = 1.0f;

				// 旧配点・旧筐体配点
				if (TJAPlayer3.DTX[nPlayer].nScoreModeTmp == 0 || TJAPlayer3.DTX[nPlayer].nScoreModeTmp == 1)
				{
					if (pChip.nチャンネル番号 == 0x15)
						this.actScore.Add((long)(300 * mag) / 10 * 10, nPlayer);//2020.10.04 "/10*10"は一の位を切り捨てるためなので消さないで。
					else
						this.actScore.Add((long)(360 * mag) / 10 * 10, nPlayer);
				}
				// AC15配点
				else if (TJAPlayer3.DTX[nPlayer].nScoreModeTmp == 2)
				{
					if (pChip.nチャンネル番号 == 0x15)
						this.actScore.Add((long)(100 * mag) / 10 * 10, nPlayer);
					else
						this.actScore.Add((long)(200 * mag) / 10 * 10, nPlayer);
				}
				// AC16配点
				else
				{
					this.actScore.Add(100L, nPlayer);
				}

				//赤か青かの分岐
				if ( sort == 0 )
				{
					this.soundRed[pChip.nPlayerSide]?.t再生を開始する();

					if ( pChip.nチャンネル番号 == 0x15 )
					{
						//CDTXMania.Skin.soundRed.t再生する();
						//CDTXMania.stage演奏ドラム画面.actChipFireTaiko.Start( 1, nPlayer );
						TJAPlayer3.stage演奏ドラム画面.FlyingNotes.Start(1, nPlayer, true);
					}
					else
					{
						//CDTXMania.Skin.soundRed.t再生する();
						//CDTXMania.stage演奏ドラム画面.actChipFireTaiko.Start( 3, nPlayer );
						TJAPlayer3.stage演奏ドラム画面.FlyingNotes.Start(3, nPlayer, true);
					}
				}
				else
				{
					this.soundBlue[pChip.nPlayerSide]?.t再生を開始する();
					if ( pChip.nチャンネル番号 == 0x15 )
					{
						//CDTXMania.Skin.soundBlue.t再生する();
						//CDTXMania.stage演奏ドラム画面.actChipFireTaiko.Start( 2, nPlayer );
						TJAPlayer3.stage演奏ドラム画面.FlyingNotes.Start(2, nPlayer, true);
					}
					else
					{
						//CDTXMania.Skin.soundBlue.t再生する();
						//CDTXMania.stage演奏ドラム画面.actChipFireTaiko.Start( 4, nPlayer );
						TJAPlayer3.stage演奏ドラム画面.FlyingNotes.Start(4, nPlayer, true);
					}
				}

				//TJAPlayer3.stage演奏ドラム画面.actTaikoLaneFlash.PlayerLane[nPlayer].Start(PlayerLane.FlashType.Hit);
			}
			else
			{
				this.b連打中[ nPlayer ] = false;
				return true;
			}

			return false;
		}

		protected bool tBalloonProcess( CDTX.CChip pChip, int nPlayer )
		{
			if ((int)(long)(CSound管理.rc演奏用タイマ.n現在時刻ms * (((double)TJAPlayer3.ConfigIni.n演奏速度) / 20.0)) >= pChip.n発声時刻ms && (int)(long)(CSound管理.rc演奏用タイマ.n現在時刻ms * (((double)TJAPlayer3.ConfigIni.n演奏速度) / 20.0)) <= pChip.nノーツ終了時刻ms)
			{
				if( pChip.nRollCount == 0 )
				{
					this.n風船残り[ nPlayer ] = pChip.nBalloon;
				}

				this.b連打中[ nPlayer ] = true;
				if(actChara.CharaAction_Balloon_Breaking[nPlayer] != null)
				{
					actChara.アクションタイマーリセット(nPlayer);
					actChara.bマイどんアクション中[nPlayer] = true;
					actChara.CharaAction_Balloon_Breaking[nPlayer] = new CCounter(0, TJAPlayer3.Skin.Game_Chara_Ptn_Balloon_Breaking[nPlayer] - 1, TJAPlayer3.Skin.Game_Chara_Balloon_Timer[nPlayer], TJAPlayer3.Timer);
				   
				}
				if (this.actBalloon.ct風船アニメ[nPlayer].b終了値に達してない)
				{
					this.actBalloon.ct風船アニメ[nPlayer] = new CCounter(0, 9, 14, TJAPlayer3.Timer);
					this.actBalloon.ct風船アニメ[nPlayer].n現在の値 = 1;
				}
				else
				{
					this.actBalloon.ct風船アニメ[nPlayer] = new CCounter(0, 9, 14, TJAPlayer3.Timer);
				}
				this.eRollState = E連打State.balloon;
				pChip.nRollCount++;
				this.n風船残り[ nPlayer ]--;

				this.n合計連打数[nPlayer]++; //  成績発表の連打数に風船を含めるように (AioiLight)
				//分岐のための処理。実装してない。

				//赤か青かの分岐
				if ( pChip.nBalloon == pChip.nRollCount )
				{
					//ﾊﾟｧｰﾝ
					TJAPlayer3.Skin.soundBalloon.t再生する();
					//CDTXMania.stage演奏ドラム画面.actChipFireTaiko.Start( 3, nPlayer ); //ここで飛ばす。飛ばされるのは大音符のみ。
					TJAPlayer3.stage演奏ドラム画面.FlyingNotes.Start(3, nPlayer);
					TJAPlayer3.stage演奏ドラム画面.Rainbow.Start( nPlayer );
					//CDTXMania.stage演奏ドラム画面.actChipFireD.Start( 0, nPlayer );

					if (TJAPlayer3.DTX[nPlayer].nScoreModeTmp != 3)
					{
						if (pChip.bGOGOTIME && !TJAPlayer3.ConfigIni.ShinuchiMode[nPlayer])
						{
							this.actScore.Add(6000L, nPlayer);
						}
						else
						{
							this.actScore.Add(5000L, nPlayer);
						}
					}
					else
					{
						this.actScore.Add(100L, nPlayer);
					}
					pChip.bHit = true;
					pChip.IsHitted = true;
					chip現在処理中の連打チップ[ nPlayer ].bHit = true;
					//this.b連打中 = false;
					//this.actChara.b風船連打中 = false;
					pChip.b可視 = false;
					this.actChara.bマイどんアクション中[nPlayer] = false; // 風船終了後、再生されていたアクションがされないようにするために追加。(AioiLight)
					if (actChara.CharaAction_Balloon_Broke[nPlayer] != null)
					{
						actChara.アクションタイマーリセット(nPlayer);
						actChara.bマイどんアクション中[nPlayer] = true;
						actChara.CharaAction_Balloon_Broke[nPlayer] = new CCounter(0, TJAPlayer3.Skin.Game_Chara_Ptn_Balloon_Broke[nPlayer] - 1, TJAPlayer3.Skin.Game_Chara_Balloon_Timer[nPlayer], TJAPlayer3.Timer);
						if(actChara.CharaAction_Balloon_Delay[nPlayer] != null )actChara.CharaAction_Balloon_Delay[nPlayer] = new CCounter(0, TJAPlayer3.Skin.Game_Chara_Balloon_Delay[nPlayer] - 1, 1, TJAPlayer3.Timer);
					}
					this.eRollState = E連打State.none;
				}
				else
				{
					if (TJAPlayer3.DTX[nPlayer].nScoreModeTmp != 3)
					{
						if (pChip.bGOGOTIME && !TJAPlayer3.ConfigIni.ShinuchiMode[nPlayer])
						{
							this.actScore.Add(360L, nPlayer);
						}
						else
						{
							this.actScore.Add(300L, nPlayer);
						}
					}
					else
					{
						this.actScore.Add(100L, nPlayer);
					}

					this.soundRed[pChip.nPlayerSide]?.t再生を開始する();
				}
				//TJAPlayer3.stage演奏ドラム画面.actTaikoLaneFlash.PlayerLane[nPlayer].Start(PlayerLane.FlashType.Hit);
			}
			else
			{
				if (chip現在処理中の連打チップ[nPlayer] != null)
					chip現在処理中の連打チップ[ nPlayer ].bHit = true;
				this.b連打中[ nPlayer ] = false;
				this.actChara.b風船連打中[nPlayer] = false;
				return false;
			}

			

			return true;
		}

		protected unsafe E判定 tチップのヒット処理( long nHitTime, CDTX.CChip pChip, bool bCorrectLane, int nNowInput, int nPlayer )
		{
			//unsafeコードにつき、デバッグ中の変更厳禁!
			bool bAutoPlay = TJAPlayer3.ConfigIni.b太鼓パートAutoPlay[nPlayer];

			if( !pChip.b可視 )
				return E判定.AutoPerfect;

			if( pChip.nチャンネル番号 != 0x15 && pChip.nチャンネル番号 != 0x16 && pChip.nチャンネル番号 != 0x17 && pChip.nチャンネル番号 != 0x18 )
			{
				//if( nPlayer == pChip.nPlayerSide )
				if (!pChip.IsMissed)
				{
					pChip.bHit = true;
					pChip.IsHitted = true;
				}
			}

			E判定 eJudgeResult = E判定.AutoPerfect;
			switch ( pChip.e楽器パート )
			{
				case E楽器パート.TAIKO:
					{
						//連打が短すぎると発声されない
						eJudgeResult = (bCorrectLane)? this.e指定時刻からChipのJUDGEを返す( nHitTime, pChip ) : E判定.Miss;

						if (!bAutoPlay && eJudgeResult != E判定.Miss)
						{
							CLagLogger.Add(nPlayer, pChip);
						}

						if ( pChip.nチャンネル番号 == 0x15 || pChip.nチャンネル番号 == 0x16 )
						{
							#region[ 連打 ]
							//---------------------------
							this.b連打中[ nPlayer ] = true;
							if( bAutoPlay )
							{
								if( TJAPlayer3.ConfigIni.bAuto先生の連打 )
								{
									if(((CSound管理.rc演奏用タイマ.n現在時刻ms * ((double)TJAPlayer3.ConfigIni.n演奏速度) / 20.0)) > ( pChip.n発声時刻ms + ( TJAPlayer3.ConfigIni.nAuto先生の連打速度 ) * pChip.nRollCount ) )
									{
										if( this.nHand[ nPlayer ] == 0 )
											this.nHand[ nPlayer ]++;
										else
											this.nHand[ nPlayer ] = 0;

										TJAPlayer3.stage演奏ドラム画面.actTaikoLaneFlash.PlayerLane[nPlayer].Start(PlayerLane.FlashType.Red);
										TJAPlayer3.stage演奏ドラム画面.FlyingNotes.Start(pChip.nチャンネル番号 == 0x15 ? 1 : 3, nPlayer, true);
										TJAPlayer3.stage演奏ドラム画面.actMtaiko.tMtaikoEvent( pChip.nチャンネル番号, this.nHand[ nPlayer ], nPlayer );
								

										this.tRollProcess( pChip, (CSound管理.rc演奏用タイマ.n現在時刻ms * (((double)TJAPlayer3.ConfigIni.n演奏速度) / 20.0)), 1, 0, 0, nPlayer );
									}
								}
							}
							else
							{
								this.eRollState = E連打State.roll;
								this.tRollProcess( pChip, (CSound管理.rc演奏用タイマ.n現在時刻ms * (((double)TJAPlayer3.ConfigIni.n演奏速度) / 20.0)), 1, nNowInput, 0, nPlayer );
							}
							if (TJAPlayer3.stage演奏ドラム画面.actPlayInfo.dbBPM < 0 && (TJAPlayer3.ConfigIni.eScrollMode == EScrollMode.HBSCROLL))
								pChip.fBMSCROLLTime -= TJAPlayer3.stage演奏ドラム画面.actPlayInfo.dbBPM * -0.05;
							//if ((int)CSound管理.rc演奏用タイマ.n現在時刻ms >= pChip.nノーツ終了時刻ms)
							//{
							//    if (actChara.CharaAction_Balloon_Breaking.b進行中)
							//    {
							//        this.actChara.bマイどんアクション中 = false; // 風船終了後、再生されていたアクションがされないようにするために追加。(AioiLight)
							//        if (actChara.CharaAction_Balloon_Miss != null)
							//        {
							//            actChara.アクションタイマーリセット();
							//            actChara.bマイどんアクション中 = true;
							//            actChara.CharaAction_Balloon_Miss = new CCounter(0, CDTXMania.Skin.Game_Chara_Ptn_Balloon_Miss - 1, CDTXMania.Skin.Game_Chara_Balloon_Timer, CDTXMania.Timer);
							//            System.Windows.Forms.MessageBox.Show("");
							//        }
							//    }

							//}

							break;
							//---------------------------
							#endregion
						}
						else if( pChip.nチャンネル番号 == 0x17 )
						{
							#region[ 風船 ]
							this.b連打中[ nPlayer ] = true;
							this.actChara.b風船連打中[nPlayer] = true;
							
							if( bAutoPlay )
							{
								if( pChip.nBalloon != 0 )
								{
									if((CSound管理.rc演奏用タイマ.n現在時刻ms * (((double)TJAPlayer3.ConfigIni.n演奏速度) / 20.0)) > ( pChip.n発声時刻ms + ( ( pChip.nノーツ終了時刻ms - pChip.n発声時刻ms ) / pChip.nBalloon ) * pChip.nRollCount ) )
									{
										if( this.nHand[ nPlayer ] == 0 )
											this.nHand[ nPlayer ]++;
										else
											this.nHand[ nPlayer ] = 0;

										TJAPlayer3.stage演奏ドラム画面.actTaikoLaneFlash.PlayerLane[nPlayer].Start(PlayerLane.FlashType.Red);
										TJAPlayer3.stage演奏ドラム画面.actMtaiko.tMtaikoEvent( pChip.nチャンネル番号, this.nHand[ nPlayer ], nPlayer );
								
										this.tBalloonProcess( pChip, nPlayer );
									}
								}
							}
							else
							{
								this.tBalloonProcess( pChip, nPlayer );
							}
							break;
							#endregion
						}
						else if( pChip.nチャンネル番号 == 0x18 )
						{
							if( pChip.nノーツ終了時刻ms <= (CSound管理.rc演奏用タイマ.n現在時刻ms * (((double)TJAPlayer3.ConfigIni.n演奏速度) / 20.0)))
							{
								this.b連打中[ nPlayer ] = false;
								//this.actChara.b風船連打中 = false;
								pChip.bHit = true;
								pChip.IsHitted = true;
								break;
							}
						}
						else if( pChip.nチャンネル番号 == 0x1F )
						{
							if( eJudgeResult != E判定.AutoPerfect && eJudgeResult != E判定.Miss )
							{
								this.actJudgeString.Start( 0, E判定.Bad, pChip.nLag, pChip, nPlayer );
								TJAPlayer3.stage演奏ドラム画面.actLaneTaiko.Start( 0x11, eJudgeResult, true, nPlayer );
								TJAPlayer3.stage演奏ドラム画面.actChipFireD.Start( 0x11, eJudgeResult, nPlayer );
							}
							break;
						}
						else
						{
							if( eJudgeResult != E判定.Miss )
							{
								pChip.bShow = false;
							}
						}

						if( eJudgeResult != E判定.AutoPerfect && eJudgeResult != E判定.Miss )
						{
							this.actJudgeString.Start( 0, bAutoPlay ? E判定.AutoPerfect : eJudgeResult, pChip.nLag, pChip, nPlayer );
							TJAPlayer3.stage演奏ドラム画面.actLaneTaiko.Start( pChip.nチャンネル番号, eJudgeResult, true, nPlayer );
							TJAPlayer3.stage演奏ドラム画面.actChipFireD.Start( pChip.nチャンネル番号, eJudgeResult, nPlayer );

							if( TJAPlayer3.ConfigIni.b太鼓パートAutoPlay[0] ? true : ( nNowInput == 2 || nNowInput == 3 ) )
							{
								//if( pChip.nチャンネル番号 == 0x13 || pChip.nチャンネル番号 == 0x1A )
								//    //CDTXMania.stage演奏ドラム画面.actChipFireD.Start( 0, nPlayer );
								//else if( pChip.nチャンネル番号 == 0x14 || pChip.nチャンネル番号 == 0x1B )
								//   //CDTXMania.stage演奏ドラム画面.actChipFireD.Start( 1, nPlayer );
							}
						}
						else if( eJudgeResult != E判定.Poor && eJudgeResult != E判定.Bad )
						{
							//this.actJudgeString.Start( 0,bAutoPlay ? E判定.Auto : eJudgeResult, pChip.nLag, pChip, nPlayer );
						}
					}
					break;
			}
			if ((pChip.e楽器パート != E楽器パート.UNKNOWN))
			{
				if (pChip.nチャンネル番号 != 0x15 && pChip.nチャンネル番号 != 0x16 && pChip.nチャンネル番号 != 0x17 && pChip.nチャンネル番号 != 0x18 && pChip.nチャンネル番号 != 0x1F)
				{
						actGauge.Damage(pChip.nコース, eJudgeResult, nPlayer);
				}

			}

			if ( eJudgeResult != E判定.Poor && eJudgeResult != E判定.Miss )
			{
				double dbUnit = (((60.0 / (TJAPlayer3.stage演奏ドラム画面.actPlayInfo.dbBPM))));

				// ランナー(たたけたやつ)
				this.actRunner.Start(nPlayer, false, pChip);

				if ((int)actGauge.db現在のゲージ値[nPlayer] >= 100 && this.bIsAlreadyMaxed[nPlayer] == false)
				{
					if(TJAPlayer3.Skin.Game_Chara_Ptn_SoulIn[nPlayer] != 0 && actChara.CharaAction_Balloon_Delay[nPlayer].b終了値に達した)
					{
						this.actChara.アクションタイマーリセット(nPlayer);
						this.actChara.ctキャラクターアクション_魂MAX[nPlayer] = new CCounter(0, TJAPlayer3.Skin.Game_Chara_Ptn_SoulIn[nPlayer] - 1, (dbUnit / TJAPlayer3.Skin.Game_Chara_Ptn_SoulIn[nPlayer]) * 2, CSound管理.rc演奏用タイマ);
						this.actChara.ctキャラクターアクション_魂MAX[nPlayer].t進行db();
						this.actChara.ctキャラクターアクション_魂MAX[nPlayer].db現在の値 = 0D;
						this.actChara.bマイどんアクション中[nPlayer] = true;
					}
					this.bIsAlreadyMaxed[nPlayer] = true;
				}
				if ((int)actGauge.db現在のゲージ値[nPlayer] >= 80 && this.bIsAlreadyCleared[nPlayer] == false)
				{
					if(TJAPlayer3.Skin.Game_Chara_Ptn_ClearIn[nPlayer] != 0 && actChara.CharaAction_Balloon_Delay[nPlayer].b終了値に達した)
					{
						this.actChara.アクションタイマーリセット(nPlayer);
						this.actChara.ctキャラクターアクション_ノルマ[nPlayer] = new CCounter(0, TJAPlayer3.Skin.Game_Chara_Ptn_ClearIn[nPlayer] - 1, (dbUnit / TJAPlayer3.Skin.Game_Chara_Ptn_ClearIn[nPlayer]) * 2, CSound管理.rc演奏用タイマ);
						this.actChara.ctキャラクターアクション_ノルマ[nPlayer].t進行db();
						this.actChara.ctキャラクターアクション_ノルマ[nPlayer].db現在の値 = 0D;
						this.actChara.bマイどんアクション中[nPlayer] = true;
					}
					this.bIsAlreadyCleared[nPlayer] = true;
					TJAPlayer3.stage演奏ドラム画面.actBackground.ClearIn(nPlayer);
				}
			}

			if ( eJudgeResult == E判定.Poor || eJudgeResult == E判定.Miss || eJudgeResult == E判定.Bad )
			{
				// ランナー(みすったやつ)
				this.actRunner.Start(nPlayer, true, pChip);
				//if (actGauge.db現在のゲージ値[nPlayer] < 80.0)
				//{
				//    CDTXMania.stage演奏ドラム画面.actBackground.tFadeOut(nPlayer);
				//}
				if ((int)actGauge.db現在のゲージ値[nPlayer] < 100 && this.bIsAlreadyMaxed[nPlayer] == true)
				{
					this.bIsAlreadyMaxed[nPlayer] = false;
				}
				if ((int)actGauge.db現在のゲージ値[nPlayer] < 80 && this.bIsAlreadyCleared[nPlayer] == true)
				{
					this.bIsAlreadyCleared[nPlayer] = false;
					//CDTXMania.stage演奏ドラム画面.actBackground.ClearIn(nPlayer);
				}
			}
			switch ( pChip.e楽器パート )
			{
				case E楽器パート.TAIKO:
					if( !bAutoPlay )
					{
						if( pChip.nチャンネル番号 == 0x15 || pChip.nチャンネル番号 == 0x16 || pChip.nチャンネル番号 == 0x17 || pChip.nチャンネル番号 == 0x18 )
							break;

						switch ( eJudgeResult )
						{
							case E判定.Perfect:
								{
									this.CBranchScore[nPlayer].nGreat++;
									this.nヒット数_Auto含まない[nPlayer].Perfect++;
									this.actCombo.n現在のコンボ数[ nPlayer ]++;
									if (this.actCombo.ctコンボ加算[nPlayer].b終了値に達してない)
									{
										this.actCombo.ctコンボ加算[nPlayer].n現在の値 = 1;
									}
									else
									{
										this.actCombo.ctコンボ加算[nPlayer].n現在の値 = 0;
									}
								}
								break;
							case E判定.Great:
							case E判定.Good:
								{
									this.CBranchScore[nPlayer].nGood++;
									this.nヒット数_Auto含まない[nPlayer].Great++;
									this.actCombo.n現在のコンボ数[ nPlayer ]++;
									//this.actCombo.ctコンボ加算 = new CCounter( 0, 8, 10, CDTXMania.Timer );
									//this.actCombo.ctコンボ加算.t進行();
									if (this.actCombo.ctコンボ加算[nPlayer].b終了値に達してない)
									{
										this.actCombo.ctコンボ加算[nPlayer].n現在の値 = 1;
									}
									else
									{
										this.actCombo.ctコンボ加算[nPlayer].n現在の値 = 0;
									}

								}
								break;
							case E判定.Poor:
							case E判定.Miss:
							case E判定.Bad:
								{
									if( pChip.nチャンネル番号 == 0x1F )
										break;
									this.CBranchScore[nPlayer].nMiss++;
									this.nヒット数_Auto含まない[nPlayer].Miss++;
									this.actCombo.n現在のコンボ数[ nPlayer ] = 0;
									this.actComboVoice.tReset(nPlayer);
									//for (int i = 0; i < 2; i++)
									//{
									//    ctChipAnime[i].t停止();
									//}
								}
								break;
							default:
								this.nヒット数_Auto含む[nPlayer][ (int) eJudgeResult ]++;
								break;
						}
					}
					else if ( bAutoPlay )
					{
						switch ( eJudgeResult )
						{
							case E判定.Perfect:
								{
									if( pChip.nチャンネル番号 != 0x15 && pChip.nチャンネル番号 != 0x16 && pChip.nチャンネル番号 != 0x17 && pChip.nチャンネル番号 != 0x18 )
									{
										this.CBranchScore[nPlayer].nGreat++;
										this.nヒット数_Auto含む[nPlayer].Perfect++;
										this.actCombo.n現在のコンボ数[ nPlayer ]++;
										//this.actCombo.ctコンボ加算.t進行();
										if (this.actCombo.ctコンボ加算[nPlayer].b終了値に達してない)
										{
											this.actCombo.ctコンボ加算[nPlayer].n現在の値 = 1;
										}
										else
										{
											this.actCombo.ctコンボ加算[nPlayer].n現在の値 = 0;
										}
									}
								}
								break;

							case E判定.Great:
							case E判定.Good:
								{
									if (pChip.nチャンネル番号 != 0x15 && pChip.nチャンネル番号 != 0x16 && pChip.nチャンネル番号 != 0x17 && pChip.nチャンネル番号 != 0x18)
									{
										this.CBranchScore[nPlayer].nGood++;
										this.nヒット数_Auto含む[nPlayer].Great++;
										this.actCombo.n現在のコンボ数[nPlayer]++;
										//this.actCombo.ctコンボ加算.t進行();
										if (this.actCombo.ctコンボ加算[nPlayer].b終了値に達してない)
										{
											this.actCombo.ctコンボ加算[nPlayer].n現在の値 = 1;
										}
										else
										{
											this.actCombo.ctコンボ加算[nPlayer].n現在の値 = 0;
										}
									}
								}
								break;
							default:
								{
									if( pChip.nチャンネル番号 != 0x15 && pChip.nチャンネル番号 != 0x16 && pChip.nチャンネル番号 != 0x17 && pChip.nチャンネル番号 != 0x18 && pChip.nチャンネル番号 != 0x1F )
									{
										this.nヒット数_Auto含む[nPlayer].Miss++;
										this.CBranchScore[nPlayer].nMiss++;
										this.actCombo.n現在のコンボ数[ nPlayer ] = 0;
										this.actComboVoice.tReset(nPlayer);
										//for (int i = 0; i < 2; i++)
										//{
										//    ctChipAnime[i].t停止();
										//}
									}
								}
								break;
						}
					}
					actDan.Update();
				
					#region[ コンボ音声 ]
					if( pChip.nチャンネル番号 < 0x15 || ( pChip.nチャンネル番号 >= 0x1A ) )
					{
						if( this.actCombo.n現在のコンボ数[ nPlayer ] % 100 == 0 && this.actCombo.n現在のコンボ数[ nPlayer ] > 0 )
						{
							this.actComboBalloon.Start( this.actCombo.n現在のコンボ数[ nPlayer ], nPlayer );
						}
						this.actComboVoice.t再生( this.actCombo.n現在のコンボ数[ nPlayer ], nPlayer );

						double dbUnit = (((60.0 / (TJAPlayer3.stage演奏ドラム画面.actPlayInfo.dbBPM))));
						dbUnit = (((60.0 / pChip.dbBPM)));

						//CDTXMania.act文字コンソール.tPrint(620, 80, C文字コンソール.Eフォント種別.白, "BPM: " + dbUnit.ToString());

						for (int i = 0; i < 2; i++)
						{
							if (this.actCombo.n現在のコンボ数[i] == 50 || this.actCombo.n現在のコンボ数[i] == 300)
							{
								ctChipAnimeLag[i] = new CCounter(0, 664, 1, TJAPlayer3.Timer);
							}
						}

						if (this.actCombo.n現在のコンボ数[nPlayer] % 10 == 0 && this.actCombo.n現在のコンボ数[nPlayer] > 0)
						{
							//if (this.actChara.bマイどんアクション中 == false)
							//{
								if (!pChip.bGOGOTIME) //2018.03.11 kairera0467 チップに埋め込んだフラグから読み取る
								{
									if (TJAPlayer3.Skin.Game_Chara_Ptn_10combo[nPlayer] != 0 && !this.actChara.ctキャラクターアクション_ノルマ[nPlayer].b進行中db && actChara.CharaAction_Balloon_Delay[nPlayer].b終了値に達した)
									{
										if (TJAPlayer3.stage演奏ドラム画面.actGauge.db現在のゲージ値[nPlayer] < 100)
										{
											// 魂ゲージMAXではない
											// ジャンプ_ノーマル
											this.actChara.アクションタイマーリセット(nPlayer);
											this.actChara.ctキャラクターアクション_10コンボ[nPlayer] = new CCounter(0, TJAPlayer3.Skin.Game_Chara_Ptn_10combo[nPlayer] - 1, (dbUnit / TJAPlayer3.Skin.Game_Chara_Ptn_10combo[nPlayer]) * 2, CSound管理.rc演奏用タイマ);
											this.actChara.ctキャラクターアクション_10コンボ[nPlayer].t進行db();
											this.actChara.ctキャラクターアクション_10コンボ[nPlayer].db現在の値 = 0D;
											this.actChara.bマイどんアクション中[nPlayer] = true;
											//this.actChara.マイどん_アクション_10コンボ();
										}
									}
									if (TJAPlayer3.Skin.Game_Chara_Ptn_10combo_Max[nPlayer] != 0 && !this.actChara.ctキャラクターアクション_魂MAX[nPlayer].b進行中db && actChara.CharaAction_Balloon_Delay[nPlayer].b終了値に達した)
									{
										if (TJAPlayer3.stage演奏ドラム画面.actGauge.db現在のゲージ値[nPlayer] >= 100)
										{
											// 魂ゲージMAX
											// ジャンプ_MAX
											this.actChara.アクションタイマーリセット(nPlayer);
											this.actChara.ctキャラクターアクション_10コンボMAX[nPlayer] = new CCounter(0, TJAPlayer3.Skin.Game_Chara_Ptn_10combo_Max[nPlayer] - 1, (dbUnit / TJAPlayer3.Skin.Game_Chara_Ptn_10combo_Max[nPlayer]) * 2, CSound管理.rc演奏用タイマ);
											this.actChara.ctキャラクターアクション_10コンボMAX[nPlayer].t進行db();
											this.actChara.ctキャラクターアクション_10コンボMAX[nPlayer].db現在の値 = 0D;
											this.actChara.bマイどんアクション中[nPlayer] = true;
										}
									}
								}
								
							//}
							else
							{
								// 魂ゲージMAX
								// ジャンプ_MAX
								//CDTXMania.stage演奏ドラム画面.actChara.マイどん_アクション_タイマーリセット();
								//CDTXMania.stage演奏ドラム画面.actChara.マイどん_アクション_スタート(CDTXMania.stage演奏ドラム画面.actChara.nキャラクターアクション_10コンボMAX枚数, 2);
							}

							/*
								if (CDTXMania.stage演奏ドラム画面.actGauge.db現在のゲージ値[0] <= 100)
								{
									this.actChara.アクションタイマーリセット();
									this.actChara.ctキャラクターアクション_魂MAX = new CCounter(0, CDTXMania.stage演奏ドラム画面.actChara.nキャラクターアクション_魂MAX枚数 - 1, (dbUnit / CDTXMania.stage演奏ドラム画面.actChara.nキャラクターアクション_魂MAX枚数) * 2, CSound管理.rc演奏用タイマ);
									this.actChara.ctキャラクターアクション_魂MAX.t進行db();
									this.actChara.ctキャラクターアクション_魂MAX.db現在の値 = 0D;
									this.actChara.bマイどんアクション中 = true;
								} else if (CDTXMania.stage演奏ドラム画面.actGauge.db現在のゲージ値[0] <= 80)
								{
									this.actChara.アクションタイマーリセット();
									this.actChara.ctキャラクターアクション_ノルマ = new CCounter(0, CDTXMania.stage演奏ドラム画面.actChara.nキャラクターアクション_ノルマ枚数 - 1, (dbUnit / CDTXMania.stage演奏ドラム画面.actChara.nキャラクターアクション_ノルマ枚数) * 2, CSound管理.rc演奏用タイマ);
									this.actChara.ctキャラクターアクション_ノルマ.t進行db();
									this.actChara.ctキャラクターアクション_ノルマ.db現在の値 = 0D;
									this.actChara.bマイどんアクション中 = true;
								}
							*/
						}
						if(this.actCombo.n現在のコンボ数[0] == 50 || this.actCombo.n現在のコンボ数[1] == 50)
						{

						}


							this.t紙吹雪_開始();
					}
					#endregion


					break;


				default:
					break;
			}
			if ( ( ( pChip.e楽器パート != E楽器パート.UNKNOWN ) ) && ( eJudgeResult != E判定.Miss ) && ( eJudgeResult != E判定.Bad ) && ( eJudgeResult != E判定.Poor ) && ( pChip.nチャンネル番号 <= 0x14 || pChip.nチャンネル番号 == 0x1A || pChip.nチャンネル番号 == 0x1B ) )
			{
				int nCombos = this.actCombo.n現在のコンボ数[ nPlayer ];
				long nInit = TJAPlayer3.DTX[nPlayer].nScoreInit[ 0, TJAPlayer3.stage選曲.n確定された曲の難易度[nPlayer]];
				long nDiff = TJAPlayer3.DTX[nPlayer].nScoreDiff[ TJAPlayer3.stage選曲.n確定された曲の難易度[nPlayer]];
				long nAddScore = 0;

				if( TJAPlayer3.ConfigIni.ShinuchiMode[nPlayer] )  //2016.07.04 kairera0467 真打モード。
				{
					if (TJAPlayer3.DTX[nPlayer].nScoreModeTmp != 3)
					{
						nAddScore = TJAPlayer3.DTX[nPlayer].nScoreInit[1, TJAPlayer3.stage選曲.n確定された曲の難易度[nPlayer]];
						if (nAddScore == 0)
						{
							//可の時に0除算をするとエラーが発生するため、それらしい数値を自動算出する。
							//メモ
							//風船1回
							nAddScore = 100;
							//( 100万 - ( ( 風船の打数 - 風船音符の数 * 300 ) + ( 風船音符の数 * 5000 ) ) ) / ノーツ数
							//(最大コンボ数＋大音符数)×初項＋(風船の総打数－風船数)×300＋風船数×5000
							//int nBallonCount = 0;
							//int nBallonNoteCount = CDTXMania.DTX.n風船数[ 2 ] + CDTXMania.DTX.n風船数[ 3 ];
							//int test = ( 1000000 - ( ( nBallonCount - nBallonNoteCount * 300 ) + ( nBallonNoteCount * 5000 ) ) ) / ( CDTXMania.DTX.nノーツ数[ 2 ] + CDTXMania.DTX.nノーツ数[ 3 ] );
						}

						if (eJudgeResult == E判定.Great || eJudgeResult == E判定.Good)
						{
							nAddScore = nAddScore / 2;
						}

						if (pChip.nチャンネル番号 == 0x13 || pChip.nチャンネル番号 == 0x14 || pChip.nチャンネル番号 == 0x1A || pChip.nチャンネル番号 == 0x1B)
						{
							nAddScore = nAddScore * 2;
						}

						this.actScore.Add(nAddScore, nPlayer);
					}
				}
				else if ( TJAPlayer3.DTX[nPlayer].nScoreModeTmp == 3 )
				{
					nAddScore = this.nScore[nPlayer, 0];
					if (eJudgeResult == E判定.Great || eJudgeResult == E判定.Good)
					{
						nAddScore = nAddScore / 2;
					}
					this.actScore.Add(nAddScore, nPlayer);
				}
				else if( TJAPlayer3.DTX[nPlayer].nScoreModeTmp == 2 )
				{
					if( nCombos < 10 )
					{
						nAddScore = this.nScore[nPlayer, 0 ];
					}
					else if( nCombos >= 10 && nCombos <= 29 )
					{
						nAddScore = this.nScore[nPlayer, 1 ];
					}
					else if( nCombos >= 30 && nCombos <= 49 )
					{
						nAddScore = this.nScore[nPlayer, 2 ];
					}
					else if( nCombos >= 50 && nCombos <= 99 )
					{
						nAddScore = this.nScore[nPlayer, 3 ];
					}
					else if (nCombos >= 100)
					{
						nAddScore = this.nScore[nPlayer, 4 ];
					}

					if (eJudgeResult == E判定.Great || eJudgeResult == E判定.Good)
					{
						nAddScore = nAddScore / 2;
					}

					if (pChip.bGOGOTIME) //2018.03.11 kairera0467 チップに埋め込んだフラグから読み取る
					{
						nAddScore = (int)(nAddScore * 1.2f);
					}

					//100コンボ毎のボーナス
					if( nCombos % 100 == 0 && nCombos > 99 )
					{
						if(this.actScore.ctボーナス加算タイマ[nPlayer].b進行中)
						{
							this.actScore.ctボーナス加算タイマ[nPlayer].t停止();
							this.actScore.BonusAdd(nPlayer);
						}
						this.actScore.ctボーナス加算タイマ[nPlayer].n現在の値 = 0;
						this.actScore.ctボーナス加算タイマ[nPlayer] = new CCounter(0, 2, 1000, TJAPlayer3.Timer);

						//combot = new System.Timers.Timer();
						//if(nPlayer == 0)
						//{
						//    combot.Elapsed += new System.Timers.ElapsedEventHandler(combotimer_event_1);
						//} else
						//{
						//    combot.Elapsed += new System.Timers.ElapsedEventHandler(combotimer_event_2);
						//}

						//combot.Interval = 2000; // ミリ秒単位で指定
						//combot.Enabled = true;
					}

					nAddScore = (int)( nAddScore / 10 );
					nAddScore = (int)( nAddScore * 10 );

					//大音符のボーナス
					if( pChip.nチャンネル番号 == 0x13 || pChip.nチャンネル番号 == 0x14 || pChip.nチャンネル番号 == 0x1A || pChip.nチャンネル番号 == 0x1B )
					{
						nAddScore = nAddScore * 2;
					}

					this.actScore.Add( nAddScore, nPlayer );
					//this.actScore.Add( E楽器パート.DRUMS, bIsAutoPlay, nAddScore );
				}
				else if( TJAPlayer3.DTX[nPlayer].nScoreModeTmp == 1 )
				{
					if (nCombos < 10)
					{
						nAddScore = this.nScore[nPlayer, 0 ];
					}
					else if( nCombos >= 10 && nCombos <= 19 )
					{
						nAddScore = this.nScore[nPlayer, 1 ];
					}
					else if( nCombos >= 20 && nCombos <= 29 )
					{
						nAddScore = this.nScore[nPlayer, 2 ];
					}
					else if( nCombos >= 30 && nCombos <= 39 )
					{
						nAddScore = this.nScore[nPlayer, 3 ];
					}
					else if( nCombos >= 40 && nCombos <= 49 )
					{
						nAddScore = this.nScore[nPlayer, 4 ];
					}
					else if( nCombos >= 50 && nCombos <= 59 )
					{
						nAddScore = this.nScore[nPlayer, 5 ];
					}
					else if( nCombos >= 60 && nCombos <= 69 )
					{
						nAddScore = this.nScore[nPlayer, 6 ];
					}
					else if( nCombos >= 70 && nCombos <= 79 )
					{
						nAddScore = this.nScore[nPlayer, 7 ];
					}
					else if( nCombos >= 80 && nCombos <= 89 )
					{
						nAddScore = this.nScore[nPlayer, 8 ];
					}
					else if( nCombos >= 90 && nCombos <= 99 )
					{
						nAddScore = this.nScore[nPlayer, 9 ];
					}
					else if( nCombos >= 100 )
					{
						nAddScore = this.nScore[nPlayer, 10 ];
					}

					if (eJudgeResult == E判定.Great || eJudgeResult == E判定.Good)
					{
						nAddScore = nAddScore / 2;
					}


					if (pChip.bGOGOTIME) //2018.03.11 kairera0467 チップに埋め込んだフラグから読み取る
						nAddScore = (int)( nAddScore * 1.2f );

					nAddScore = (int)( nAddScore / 10.0 );
					nAddScore = (int)( nAddScore * 10 );

					//大音符のボーナス
					if( pChip.nチャンネル番号 == 0x13 || pChip.nチャンネル番号 == 0x14 || pChip.nチャンネル番号 == 0x1A || pChip.nチャンネル番号 == 0x1B )
					{
						nAddScore = nAddScore * 2;
					}

					this.actScore.Add( nAddScore, nPlayer );
				}
				else if (TJAPlayer3.DTX[nPlayer].nScoreModeTmp == 0)
				{
					if (nCombos < 200)
					{
						nAddScore = 1000;
					}
					else
					{
						nAddScore = 2000;
					}
					
					if (eJudgeResult == E判定.Great || eJudgeResult == E判定.Good)
						nAddScore = nAddScore / 2;

					if (pChip.bGOGOTIME) //2018.03.11 kairera0467 チップに埋め込んだフラグから読み取る
						nAddScore = (int)(nAddScore * 1.2f);

					//大音符のボーナス
					if (pChip.nチャンネル番号 == 0x13 || pChip.nチャンネル番号 == 0x25 )
					{
						nAddScore = nAddScore * 2;
					}


					this.actScore.Add( nAddScore, nPlayer );
					//this.actScore.Add( E楽器パート.DRUMS, bIsAutoPlay, nAddScore );              
				}

				//キーを押したときにスコア情報 + nAddScoreを置き換える様に
				this.CBranchScore[nPlayer].nScore = (int)(this.actScore.GetScore(nPlayer) + nAddScore);
			}
			return E判定.AutoPerfect;
		}

		protected void t分岐状況チェック( int n現在時刻, int nPlayer )
		{
			CDTX dTX = TJAPlayer3.DTX[nPlayer];

			for( int i = this.n現在のトップChip; i < dTX.listChip.Count; i++ )
			{
				if( ( dTX.listChip[ i ].nチャンネル番号 <= 0x11 && dTX.listChip[ i ].nチャンネル番号 >= 0x18 ) != false )
				{
					if( dTX.listChip[ i ].nコース == this.n現在のコース[ nPlayer ] )
					{
						dTX.listChip[i].b可視 = true;
					}
					else
					{
						dTX.listChip[i].b可視 = false;
					}
				}
			}
		}

		protected void tチップのヒット処理_BadならびにTight時のMiss(int nCource)//2020.04.25 Mr-Ojii akasoko26さんのコードをもとに変更
		{
			//ChipのCourseをベースにゲージの伸びを調節
			actGauge.Damage(nCource, E判定.Miss, 0 );
		}

		protected CDTX.CChip r指定時刻に一番近い未ヒットChipを過去方向優先で検索する( long nTime, int nPlayer )
		{
			//sw2.Start();
			int nIndex_InitialPositionSearchingToPast;
			int nTimeDiff;
			int count = listChip[ nPlayer ].Count;
			if ( count <= 0 )			// 演奏データとして1個もチップがない場合は
			{
				//sw2.Stop();
				return null;
			}

			int nIndex_NearestChip_Future = nIndex_InitialPositionSearchingToPast = this.n現在のトップChip;
			if ( this.n現在のトップChip >= count )		// その時点で演奏すべきチップが既に全部無くなっていたら
			{
				nIndex_NearestChip_Future  = nIndex_InitialPositionSearchingToPast = count - 1;
			}


			// int nIndex_NearestChip_Future = nIndex_InitialPositionSearchingToFuture;
//			while ( nIndex_NearestChip_Future < count )	// 未来方向への検索
			for ( ; nIndex_NearestChip_Future < count; nIndex_NearestChip_Future++ )
			{
				if( nIndex_NearestChip_Future < 0 )
					continue;

				CDTX.CChip chip = listChip[ nPlayer ][ nIndex_NearestChip_Future ];
				if ( !chip.bHit && chip.b可視 )
				{
					if ( ( ( 0x11 <= chip.nチャンネル番号 ) && ( chip.nチャンネル番号 <= 0x18 ) ) || chip.nチャンネル番号 == 0x1A || chip.nチャンネル番号 == 0x1B || chip.nチャンネル番号 == 0x1F )
					{
						if ( chip.n発声時刻ms > nTime )
						{
							break;
						}
						nIndex_InitialPositionSearchingToPast = nIndex_NearestChip_Future;
					}
				}
				if( chip.bHit && chip.b可視 ) // 2015.11.5 kairera0467 連打対策
				{
					if( ( 0x15 <= chip.nチャンネル番号) && ( chip.nチャンネル番号 <= 0x17 ) )
					{
						if (chip.nノーツ終了時刻ms > nTime)
						{
							nIndex_InitialPositionSearchingToPast = nIndex_NearestChip_Future;
							break;
						}
					}
				}
//				nIndex_NearestChip_Future++;
			}


			int nIndex_NearestChip_Past = nIndex_InitialPositionSearchingToPast;
//			while ( nIndex_NearestChip_Past >= 0 )		// 過去方向への検索
			for ( ; nIndex_NearestChip_Past >= 0; nIndex_NearestChip_Past-- )
			{
				CDTX.CChip chip = listChip[ nPlayer ][ nIndex_NearestChip_Past ];
				//if ( (!chip.bHit && chip.b可視 ) && ( (  0x93 <= chip.nチャンネル番号 ) && ( chip.nチャンネル番号 <= 0x99 ) ) )
				if ( (!chip.bHit && chip.b可視 ) && ( (  0x11 <= chip.nチャンネル番号 ) && ( chip.nチャンネル番号 <= 0x17 ) ) || chip.nチャンネル番号 == 0x1A || chip.nチャンネル番号 == 0x1B || chip.nチャンネル番号 == 0x1F )
					{
						break;
					}
				//2015.11.5 kairera0467 連打対策
				else if ( ( chip.b可視 ) && ( (  0x15 <= chip.nチャンネル番号 ) && ( chip.nチャンネル番号 <= 0x17 ) ) )
					{
						break;
					}
//				nIndex_NearestChip_Past--;
			}
			if ( ( nIndex_NearestChip_Future >= count ) && ( nIndex_NearestChip_Past < 0 ) )	// 検索対象が過去未来どちらにも見つからなかった場合
			{
				//sw2.Stop();
				return null;
			}
			CDTX.CChip nearestChip;	// = null;	// 以下のifブロックのいずれかで必ずnearestChipには非nullが代入されるので、null初期化を削除
			if ( nIndex_NearestChip_Future >= count )											// 検索対象が未来方向には見つからなかった(しかし過去方向には見つかった)場合
			{
				nearestChip = listChip[ nPlayer ][ nIndex_NearestChip_Past ];
//				nTimeDiff = Math.Abs( (int) ( nTime - nearestChip.n発声時刻ms ) );
			}
			else if ( nIndex_NearestChip_Past < 0 )												// 検索対象が過去方向には見つからなかった(しかし未来方向には見つかった)場合
			{
				nearestChip = listChip[ nPlayer ][ nIndex_NearestChip_Future ];
//				nTimeDiff = Math.Abs( (int) ( nTime - nearestChip.n発声時刻ms ) );
			}
			else
			{
				int nTimeDiff_Future = Math.Abs( (int) ( nTime - listChip[ nPlayer ][ nIndex_NearestChip_Future ].n発声時刻ms ) );
				int nTimeDiff_Past   = Math.Abs( (int) ( nTime - listChip[ nPlayer ][ nIndex_NearestChip_Past   ].n発声時刻ms ) );
				if ( nTimeDiff_Future < nTimeDiff_Past )
				{
					if( !listChip[ nPlayer ][ nIndex_NearestChip_Past ].bHit && ( listChip[ nPlayer ][ nIndex_NearestChip_Past ].n発声時刻ms + ( 108 ) >= nTime ) )
					{
						nearestChip = listChip[ nPlayer ][ nIndex_NearestChip_Past ];
					}
					else
						nearestChip = listChip[ nPlayer ][ nIndex_NearestChip_Future ];
//					nTimeDiff = Math.Abs( (int) ( nTime - nearestChip.n発声時刻ms ) );
				}
				else
				{
					nearestChip = listChip[ nPlayer ][ nIndex_NearestChip_Past ];
//					nTimeDiff = Math.Abs( (int) ( nTime - nearestChip.n発声時刻ms ) );
				}

				//2015.11.5 kairera0467　連打音符の判定
				if( listChip[ nPlayer ][ nIndex_NearestChip_Future ].nチャンネル番号 >= 0x15 && listChip[ nPlayer ][ nIndex_NearestChip_Future ].nチャンネル番号 <= 0x17 )
				{
					if( listChip[ nPlayer ][ nIndex_NearestChip_Future ].n発声時刻ms <= nTime && listChip[ nPlayer ][ nIndex_NearestChip_Future ].nノーツ終了時刻ms >= nTime )
					{
						nearestChip = listChip[ nPlayer ][ nIndex_NearestChip_Future ];
					}
				}
			}
			nTimeDiff = Math.Abs( (int) ( nTime - nearestChip.n発声時刻ms ) );
			int n検索範囲時間ms = 0;
			if ( ( n検索範囲時間ms > 0 ) && ( nTimeDiff > n検索範囲時間ms ) )					// チップは見つかったが、検索範囲時間外だった場合
			{
				//sw2.Stop();
				return null;
			}
			//sw2.Stop();
			return nearestChip;
		}

		/// <summary>
		/// 最も判定枠に近いノーツを返します。
		/// </summary>
		/// <param name="nowTime">判定時の時間。</param>
		/// <param name="player">プレイヤー。</param>
		/// <returns>最も判定枠に近いノーツ。</returns>
		protected CDTX.CChip GetChipOfNearest(long nowTime, int player)
		{
			var nearestChip = new CDTX.CChip();
			var count = listChip[player].Count;
			var chips = listChip[player];
			var startPosision = NowProcessingChip[player];
			CDTX.CChip pastChip; // 判定されるべき過去ノート
			CDTX.CChip futureChip; // 判定されるべき未来ノート
			var pastJudge = E判定.Miss;
			var futureJudge = E判定.Miss;

			if (count <= 0)
			{
				return null;
			}

			if(startPosision >= count)
			{
				startPosision -= 1;
			}

			#region 過去のノーツで、かつ可判定以上のノーツの決定
			CDTX.CChip afterChip = null;
			for (int pastNote = startPosision - 1; ; pastNote--)
			{
				if (pastNote < 0)
				{
					pastChip = afterChip != null ? afterChip : null; // afterChipに過去の判定があるかもしれないので
					break;
				}
				var processingChip = chips[pastNote];

				if (!processingChip.IsHitted && processingChip.b可視) // まだ判定されてない音符
				{
					if (((0x11 <= processingChip.nチャンネル番号) && (processingChip.nチャンネル番号 <= 0x18))
						|| processingChip.nチャンネル番号 == 0x1A
						|| processingChip.nチャンネル番号 == 0x1B
						|| processingChip.nチャンネル番号 == 0x1F) // 音符のチャンネルである
					{
						var thisChipJudge = pastJudge = e指定時刻からChipのJUDGEを返すImpl(nowTime, processingChip);
						if (thisChipJudge != E判定.Miss)
						{
							// 判定が見過ごし不可ではない(=たたいて不可以上)
							// その前のノートがもしかしたら存在して、可以上の判定かもしれないからまだ処理を続行する。
							afterChip = processingChip;
							continue;
						}
						else
						{
							// 判定が不可だった
							// その前のノーツを過去で可以上のノート(つまり判定されるべきノート)とする。
							pastChip = afterChip;
							break; // 検索終わり
						}
					}
				}
				if (processingChip.IsHitted && processingChip.b可視) // 連打
				{
					if ((0x15 <= processingChip.nチャンネル番号) && (processingChip.nチャンネル番号 <= 0x17))
					{
						if (processingChip.nノーツ終了時刻ms > nowTime)
						{
							pastChip = processingChip;
							break;
						}
					}
				}
			}
			#endregion
			
			#region 未来のノーツで、かつ可判定以上のノーツの決定
			for (int futureNote = startPosision; ; futureNote++)
			{
				if (futureNote >= count)
				{
					futureChip = null;
					break;
				}
				var processingChip = chips[futureNote];

				if (!processingChip.IsHitted && processingChip.b可視) // まだ判定されてない音符
				{
					if (((0x11 <= processingChip.nチャンネル番号) && (processingChip.nチャンネル番号 <= 0x18))
						|| processingChip.nチャンネル番号 == 0x1A
						|| processingChip.nチャンネル番号 == 0x1B
						|| processingChip.nチャンネル番号 == 0x1F) // 音符のチャンネルである
					{
						var thisChipJudge = futureJudge = e指定時刻からChipのJUDGEを返すImpl(nowTime, processingChip);
						if (thisChipJudge != E判定.Miss)
						{
							// 判定が見過ごし不可ではない(=たたいて不可以上)
							// そのノートを処理すべきなので、検索終わり。
							futureChip = processingChip;
							break; // 検索終わり
						}
						else
						{
							// 判定が不可だった
							// つまり未来に処理すべきノートはないので、検索終わり。
							futureChip = null; // 今処理中のノート
							break; // 検索終わり
						}
					}
				}
			}
			#endregion

			#region 過去のノーツが見つかったらそれを返却、そうでなければ未来のノーツを返却
			if ((pastJudge == E判定.Miss || pastJudge == E判定.Poor) && (pastJudge != E判定.Miss && pastJudge != E判定.Poor))
			{
				// 過去の判定が不可で、未来の判定が可以上なら未来を返却。
				nearestChip = futureChip;
			}
			else if (futureChip == null && pastChip != null)
			{
				// 未来に処理するべきノートがなかったので、過去の処理すべきノートを返す。
				nearestChip = pastChip;
			}
			else if (pastChip == null && futureChip != null)
			{
				// 過去の検索が該当なしだったので、未来のノートを返す。
				nearestChip = futureChip;
			}
			else
			{
				// 基本的には過去のノートを返す。
				nearestChip = pastChip;
			}
			#endregion
#if DEBUG
			if(player == 0)
			{
				TJAPlayer3.act文字コンソール.tPrint(0, 0, C文字コンソール.Eフォント種別.白, pastChip != null ? pastChip.ToString() : "null");
				TJAPlayer3.act文字コンソール.tPrint(0, 20, C文字コンソール.Eフォント種別.白, futureChip != null ? futureChip.ToString() : "null");
				TJAPlayer3.act文字コンソール.tPrint(0, 40, C文字コンソール.Eフォント種別.白, nearestChip != null ? nearestChip.ToString() : "null");
				TJAPlayer3.act文字コンソール.tPrint(0, 60, C文字コンソール.Eフォント種別.白, startPosision.ToString());

			}
#endif
			return nearestChip;
		}
		/// <summary>
		/// 最も判定枠に近いドンカツを返します。
		/// </summary>
		/// <param name="nowTime">判定時の時間。</param>
		/// <param name="player">プレイヤー。</param>
		/// <param name="don">ドンかどうか。</param>
		/// <returns>最も判定枠に近いノーツ。</returns>
		protected CDTX.CChip GetChipOfNearest(long nowTime, int player, bool don)
		{
			var nearestChip = new CDTX.CChip();
			var count = listChip[player].Count;
			var chips = listChip[player];
			var startPosision = NowProcessingChip[player];
			CDTX.CChip pastChip; // 判定されるべき過去ノート
			CDTX.CChip futureChip; // 判定されるべき未来ノート
			var pastJudge = E判定.Miss;
			var futureJudge = E判定.Miss;

			bool GetDon(CDTX.CChip note)
			{
				return note.nチャンネル番号 == 0x11 || note.nチャンネル番号 == 0x13 || note.nチャンネル番号 == 0x1A || note.nチャンネル番号 == 0x1F;
			}
			bool GetKatsu(CDTX.CChip note)
			{
				return note.nチャンネル番号 == 0x12 || note.nチャンネル番号 == 0x14 || note.nチャンネル番号 == 0x1B || note.nチャンネル番号 == 0x1F;
			}

			if (count <= 0)
			{
				return null;
			}

			if (startPosision >= count)
			{
				startPosision -= 1;
			}

			#region 過去のノーツで、かつ可判定以上のノーツの決定
			CDTX.CChip afterChip = null;
			for (int pastNote = startPosision - 1; ; pastNote--)
			{
				if (pastNote < 0)
				{
					pastChip = afterChip != null ? afterChip : null; // afterChipに過去の判定があるかもしれないので
					break;
				}
				var processingChip = chips[pastNote];

				if (!processingChip.IsHitted && processingChip.b可視) // まだ判定されてない音符
				{
					if (don ? GetDon(processingChip) : GetKatsu(processingChip)) // 音符のチャンネルである
					{
						var thisChipJudge = pastJudge = e指定時刻からChipのJUDGEを返すImpl(nowTime, processingChip);
						if (thisChipJudge != E判定.Miss)
						{
							// 判定が見過ごし不可ではない(=たたいて不可以上)
							// その前のノートがもしかしたら存在して、可以上の判定かもしれないからまだ処理を続行する。
							afterChip = processingChip;
							continue;
						}
						else
						{
							// 判定が不可だった
							// その前のノーツを過去で可以上のノート(つまり判定されるべきノート)とする。
							pastChip = afterChip;
							break; // 検索終わり
						}
					}
				}
				if (processingChip.IsHitted && processingChip.b可視) // 連打
				{
					if ((0x15 <= processingChip.nチャンネル番号) && (processingChip.nチャンネル番号 <= 0x17))
					{
						if (processingChip.nノーツ終了時刻ms > nowTime)
						{
							pastChip = processingChip;
							break;
						}
					}
				}
			}
			#endregion

			#region 未来のノーツで、かつ可判定以上のノーツの決定
			for (int futureNote = startPosision; ; futureNote++)
			{
				if (futureNote >= count)
				{
					futureChip = null;
					break;
				}
				var processingChip = chips[futureNote];

				if (!processingChip.IsHitted && processingChip.b可視) // まだ判定されてない音符
				{
					if (don ? GetDon(processingChip) : GetKatsu(processingChip)) // 音符のチャンネルである
					{
						var thisChipJudge = futureJudge = e指定時刻からChipのJUDGEを返すImpl(nowTime, processingChip);
						if (thisChipJudge != E判定.Miss)
						{
							// 判定が見過ごし不可ではない(=たたいて不可以上)
							// そのノートを処理すべきなので、検索終わり。
							futureChip = processingChip;
							break; // 検索終わり
						}
						else
						{
							// 判定が不可だった
							// つまり未来に処理すべきノートはないので、検索終わり。
							futureChip = null; // 今処理中のノート
							break; // 検索終わり
						}
					}
				}
			}
			#endregion

			#region 過去のノーツが見つかったらそれを返却、そうでなければ未来のノーツを返却
			if ((pastJudge == E判定.Miss || pastJudge == E判定.Poor) && (pastJudge != E判定.Miss && pastJudge != E判定.Poor))
			{
				// 過去の判定が不可で、未来の判定が可以上なら未来を返却。
				nearestChip = futureChip;
			}
			else if (futureChip == null && pastChip != null)
			{
				// 未来に処理するべきノートがなかったので、過去の処理すべきノートを返す。
				nearestChip = pastChip;
			}
			else if (pastChip == null && futureChip != null)
			{
				// 過去の検索が該当なしだったので、未来のノートを返す。
				nearestChip = futureChip;
			}
			else
			{
				// 基本的には過去のノートを返す。
				nearestChip = pastChip;
			}
			#endregion
#if DEBUG
			if(player == 0)
			{
				TJAPlayer3.act文字コンソール.tPrint(0, 0, C文字コンソール.Eフォント種別.白, pastChip != null ? pastChip.ToString() : "null");
				TJAPlayer3.act文字コンソール.tPrint(0, 20, C文字コンソール.Eフォント種別.白, futureChip != null ? futureChip.ToString() : "null");
				TJAPlayer3.act文字コンソール.tPrint(0, 40, C文字コンソール.Eフォント種別.白, nearestChip != null ? nearestChip.ToString() : "null");
				TJAPlayer3.act文字コンソール.tPrint(0, 60, C文字コンソール.Eフォント種別.白, startPosision.ToString());

			}
#endif
			return nearestChip;
		}


		protected CDTX.CChip r指定時刻に一番近い未ヒットChip( long nTime, int nChannel, int nInputAdjustTime, int n検索範囲時間ms, int nPlayer )
		{
			//sw2.Start();
//Trace.TraceInformation( "nTime={0}, nChannel={1:x2}, 現在のTop={2}", nTime, nChannel,CDTXMania.DTX.listChip[ this.n現在のトップChip ].n発声時刻ms );
			nTime += nInputAdjustTime;

			int nIndex_InitialPositionSearchingToPast;
			int nTimeDiff;
			if ( this.n現在のトップChip == -1 )			// 演奏データとして1個もチップがない場合は
			{
				//sw2.Stop();
				return null;
			}
			int count = listChip[ nPlayer ].Count;
			int nIndex_NearestChip_Future = nIndex_InitialPositionSearchingToPast = this.n現在のトップChip;
			if ( this.n現在のトップChip >= count )		// その時点で演奏すべきチップが既に全部無くなっていたら
			{
				nIndex_NearestChip_Future  = nIndex_InitialPositionSearchingToPast = count - 1;
			}
			// int nIndex_NearestChip_Future = nIndex_InitialPositionSearchingToFuture;
//			while ( nIndex_NearestChip_Future < count )	// 未来方向への検索
			for ( ; nIndex_NearestChip_Future < count; nIndex_NearestChip_Future++ )
			{
				CDTX.CChip chip = listChip[ nPlayer ][ nIndex_NearestChip_Future ];
				if ( !chip.bHit )
				{
					if( ( 0x11 <= nChannel) && ( nChannel <= 0x1F ) )
					{
						if ((chip.nチャンネル番号 == nChannel) || (chip.nチャンネル番号 == (nChannel + 0x20)))
						{
							if (chip.n発声時刻ms > nTime)
							{
								break;
							}
							nIndex_InitialPositionSearchingToPast = nIndex_NearestChip_Future;
						}
						continue;
					}

					//if ( ( ( 0xDE <= nChannel ) && ( nChannel <= 0xDF ) ) )
					if ( ( ( 0xDF == nChannel ) ) )
					{
						if( chip.nチャンネル番号 == nChannel )
						{
							if ( chip.n発声時刻ms > nTime )
							{
								break;
							}
							nIndex_InitialPositionSearchingToPast = nIndex_NearestChip_Future;
						}
					}

					if ( ( ( 0x50 == nChannel ) ) )
					{
						if( chip.nチャンネル番号 == nChannel )
						{
							if ( chip.n発声時刻ms > nTime )
							{
								break;
							}
							nIndex_InitialPositionSearchingToPast = nIndex_NearestChip_Future;
						}
					}

				}
//				nIndex_NearestChip_Future++;
			}
			int nIndex_NearestChip_Past = nIndex_InitialPositionSearchingToPast;
//			while ( nIndex_NearestChip_Past >= 0 )		// 過去方向への検索
			for ( ; nIndex_NearestChip_Past >= 0; nIndex_NearestChip_Past-- )
			{
				CDTX.CChip chip = listChip[ nPlayer ][ nIndex_NearestChip_Past ];
				if ( (!chip.bHit) &&
						(
							(
								( ( ( ( nChannel >= 0x11 ) && ( nChannel <= 0x14 ) ) || nChannel == 0x1A || nChannel == 0x1B || nChannel == 0x1F ) && ( chip.nチャンネル番号 == nChannel ) )
							)
							||
							(
							//	( ( ( nChannel >= 0xDE ) && ( nChannel <= 0xDF ) ) && ( chip.nチャンネル番号 == nChannel ) )
								( ( ( nChannel == 0xDF ) ) && ( chip.nチャンネル番号 == nChannel ) )
							)
							||
							(
							//	( ( ( nChannel >= 0xDE ) && ( nChannel <= 0xDF ) ) && ( chip.nチャンネル番号 == nChannel ) )
								( ( ( nChannel == 0x50 ) ) && ( chip.nチャンネル番号 == nChannel ) )
							)
						)
					)
					{
						break;
					}
//				nIndex_NearestChip_Past--;
			}
			if ( ( nIndex_NearestChip_Future >= count ) && ( nIndex_NearestChip_Past < 0 ) )	// 検索対象が過去未来どちらにも見つからなかった場合
			{
				//sw2.Stop();
				return null;
			}
			CDTX.CChip nearestChip;	// = null;	// 以下のifブロックのいずれかで必ずnearestChipには非nullが代入されるので、null初期化を削除
			if ( nIndex_NearestChip_Future >= count )											// 検索対象が未来方向には見つからなかった(しかし過去方向には見つかった)場合
			{
				nearestChip = listChip[ nPlayer ][ nIndex_NearestChip_Past ];
//				nTimeDiff = Math.Abs( (int) ( nTime - nearestChip.n発声時刻ms ) );
			}
			else if ( nIndex_NearestChip_Past < 0 )												// 検索対象が過去方向には見つからなかった(しかし未来方向には見つかった)場合
			{
				nearestChip = listChip[ nPlayer ][ nIndex_NearestChip_Future ];
//				nTimeDiff = Math.Abs( (int) ( nTime - nearestChip.n発声時刻ms ) );
			}
			else
			{
				int nTimeDiff_Future = Math.Abs( (int) ( nTime - listChip[ nPlayer ][ nIndex_NearestChip_Future ].n発声時刻ms ) );
				int nTimeDiff_Past   = Math.Abs( (int) ( nTime - listChip[ nPlayer ][ nIndex_NearestChip_Past   ].n発声時刻ms ) );

				if( nChannel == 0xDF ) //0xDFの場合は過去方向への検索をしない
				{
					return listChip[ nPlayer ][ nIndex_NearestChip_Future ];
				}

				if ( nTimeDiff_Future < nTimeDiff_Past )
				{
					nearestChip = listChip[ nPlayer ][ nIndex_NearestChip_Future ];
//					nTimeDiff = Math.Abs( (int) ( nTime - nearestChip.n発声時刻ms ) );
				}
				else
				{
					nearestChip = listChip[ nPlayer ][ nIndex_NearestChip_Past ];
//					nTimeDiff = Math.Abs( (int) ( nTime - nearestChip.n発声時刻ms ) );
				}
			}
			nTimeDiff = Math.Abs( (int) ( nTime - nearestChip.n発声時刻ms ) );
			if ( ( n検索範囲時間ms > 0 ) && ( nTimeDiff > n検索範囲時間ms ) )					// チップは見つかったが、検索範囲時間外だった場合
			{
				//sw2.Stop();
				return null;
			}
			//sw2.Stop();
			return nearestChip;
		}
		public bool r検索範囲内にチップがあるか調べる( long nTime, int nInputAdjustTime, int n検索範囲時間ms, int nPlayer )
		{
			nTime += nInputAdjustTime;

			for ( int i = 0; i < listChip[ nPlayer ].Count; i++ )
			{
				CDTX.CChip chip = listChip[ nPlayer ][ i ];
				if ( !chip.bHit )
				{
					if ( ( ( 0x11 <= chip.nチャンネル番号 ) && ( chip.nチャンネル番号 <= 0x14 ) ) || chip.nチャンネル番号 == 0x1A || chip.nチャンネル番号 == 0x1B )
					{
						if ( chip.n発声時刻ms < nTime + n検索範囲時間ms )
						{
							if( chip.nコース == this.n現在のコース[ nPlayer ] ) //2016.06.14 kairera0467 譜面分岐も考慮するようにしてみる。
								return true;
						}
					}
				}
			}
			
			return false;
		}

		protected void ChangeInputAdjustTimeInPlaying( IInputDevice keyboard, int plusminus )		// #23580 2011.1.16 yyagi UI for InputAdjustTime in playing screen.
		{
			int offset;
			if (keyboard.bキーが押されている((int)SlimDXKeys.Key.LeftControl) ||
				keyboard.bキーが押されている((int)SlimDXKeys.Key.RightControl))
			{
				offset = plusminus;
			}
			else
			{
				offset = plusminus * 10;
			}

			var newInputAdjustTimeMs = (TJAPlayer3.ConfigIni.nInputAdjustTimeMs + offset).Clamp(-99, 99);
			TJAPlayer3.ConfigIni.nInputAdjustTimeMs = newInputAdjustTimeMs;
		}

		protected abstract void t入力処理_ドラム();
		protected abstract void ドラムスクロール速度アップ(int nPlayer);
		protected abstract void ドラムスクロール速度ダウン(int nPlayer);
		protected void tキー入力()
		{
			IInputDevice keyboard = TJAPlayer3.Input管理.Keyboard;
			if ( keyboard.bキーが押された( (int)SlimDXKeys.Key.F1 ) &&
				( keyboard.bキーが押されている( (int)SlimDXKeys.Key.RightShift ) || keyboard.bキーが押されている( (int)SlimDXKeys.Key.LeftShift ) ) )
			{	// shift+f1 (pause)
				//this.bPAUSE = !this.bPAUSE;
				//if ( this.bPAUSE )
				//{
				//    CSound管理.rc演奏用タイマ.t一時停止();
				//    CDTXMania.Timer.t一時停止();
				//    CDTXMania.DTX.t全チップの再生一時停止();
				//}
				//else
				//{
				//    CSound管理.rc演奏用タイマ.t再開();
				//    CDTXMania.Timer.t再開();
				//    CDTXMania.DTX.t全チップの再生再開();
				//}
			}
			if ( ( !this.bPAUSE && ( base.eフェーズID != CStage.Eフェーズ.演奏_STAGE_FAILED ) ) && ( base.eフェーズID != CStage.Eフェーズ.演奏_STAGE_FAILED_フェードアウト ) )
			{
				this.t入力処理_ドラム();
				if (keyboard.bキーが押された((int)SlimDXKeys.Key.UpArrow) && (keyboard.bキーが押されている((int)SlimDXKeys.Key.RightShift) || keyboard.bキーが押されている((int)SlimDXKeys.Key.LeftShift)))
				{   // shift (+ctrl) + UpArrow (BGMAdjust)
					TJAPlayer3.DTX[0].t各自動再生音チップの再生時刻を変更する((keyboard.bキーが押されている((int)SlimDXKeys.Key.LeftControl) || keyboard.bキーが押されている((int)SlimDXKeys.Key.RightControl)) ? 1 : 10);
					TJAPlayer3.DTX[0].tWave再生位置自動補正();
				}
				else if (keyboard.bキーが押された((int)SlimDXKeys.Key.DownArrow) && (keyboard.bキーが押されている((int)SlimDXKeys.Key.RightShift) || keyboard.bキーが押されている((int)SlimDXKeys.Key.LeftShift)))
				{   // shift + DownArrow (BGMAdjust)
					TJAPlayer3.DTX[0].t各自動再生音チップの再生時刻を変更する((keyboard.bキーが押されている((int)SlimDXKeys.Key.LeftControl) || keyboard.bキーが押されている((int)SlimDXKeys.Key.RightControl)) ? -1 : -10);
					TJAPlayer3.DTX[0].tWave再生位置自動補正();
				}
				else if (keyboard.bキーが押された((int)SlimDXKeys.Key.UpArrow))
				{   // UpArrow(scrollspeed up)
					if (keyboard.bキーが押されている((int)SlimDXKeys.Key.LeftControl) || keyboard.bキーが押されている((int)SlimDXKeys.Key.RightControl))//2020.05.29 Mr-Ojii Ctrlを押しているかどうかで、対象プレイヤーの変更
						ドラムスクロール速度アップ(1);
					else
						ドラムスクロール速度アップ(0);
				}
				else if (keyboard.bキーが押された((int)SlimDXKeys.Key.DownArrow))
				{   // DownArrow (scrollspeed down)
					if (keyboard.bキーが押されている((int)SlimDXKeys.Key.LeftControl) || keyboard.bキーが押されている((int)SlimDXKeys.Key.RightControl))
						ドラムスクロール速度ダウン(1);
					else
						ドラムスクロール速度ダウン(0);
				}
				else if (keyboard.bキーが押された((int)SlimDXKeys.Key.Delete))
				{   // del (debug info)
					TJAPlayer3.ConfigIni.b演奏情報を表示する = !TJAPlayer3.ConfigIni.b演奏情報を表示する;
				}
				else if (keyboard.bキーが押された((int)SlimDXKeys.Key.LeftArrow))      // #24243 2011.1.16 yyagi UI for InputAdjustTime in playing screen.
				{
					ChangeInputAdjustTimeInPlaying(keyboard, -1);
				}
				else if (keyboard.bキーが押された((int)SlimDXKeys.Key.RightArrow))     // #24243 2011.1.16 yyagi UI for InputAdjustTime in playing screen.
				{
					ChangeInputAdjustTimeInPlaying(keyboard, +1);
				}
				else if ((base.eフェーズID == CStage.Eフェーズ.共通_通常状態) && (keyboard.bキーが押された((int)SlimDXKeys.Key.Escape)) && !this.actPauseMenu.bIsActivePopupMenu)
				{   // escape (exit)
					this.t演奏中止();
				}
				else if (keyboard.bキーが押された((int)SlimDXKeys.Key.D1) && TJAPlayer3.ConfigIni.b太鼓パートAutoPlay[0])//2020.04.25 Mr-Ojii akasoko26さんのコードをもとに変更
				{
					if (!TJAPlayer3.DTX[0].bHasBranch[TJAPlayer3.stage選曲.n確定された曲の難易度[0]]) return;

					//listBRANCHを廃止したため強制分岐の開始値を
					//rc演奏用タイマ.n現在時刻msから引っ張ることに

					//判定枠に一番近いチップの情報を元に一小節分の値を計算する. 2020.04.21 akasoko26

					var p判定枠に最も近いチップ = r指定時刻に一番近い未ヒットChipを過去方向優先で検索する((long)(CSound管理.rc演奏用タイマ.n現在時刻ms * (((double)TJAPlayer3.ConfigIni.n演奏速度) / 20.0)), 0);
					double db一小節後 = 0.0;
					if (p判定枠に最も近いチップ != null)
						db一小節後 = ((15000.0 / p判定枠に最も近いチップ.dbBPM * (p判定枠に最も近いチップ.fNow_Measure_s / p判定枠に最も近いチップ.fNow_Measure_m)) * 16.0);

					this.t分岐処理(0, 0, (CSound管理.rc演奏用タイマ.n現在時刻ms * (((double)TJAPlayer3.ConfigIni.n演奏速度) / 20.0)) + db一小節後);

					TJAPlayer3.stage演奏ドラム画面.actLaneTaiko.t分岐レイヤー_コース変化(TJAPlayer3.stage演奏ドラム画面.actLaneTaiko.stBranch[0].nAfter, 0, 0);
					TJAPlayer3.stage演奏ドラム画面.actMtaiko.tBranchEvent(TJAPlayer3.stage演奏ドラム画面.actMtaiko.After[0], 0, 0);
					this.n現在のコース[0] = 0;
					this.n次回のコース[0] = 0;
					this.nレーン用表示コース[0] = 0;

					this.b強制的に分岐させた[0] = true;
				}
				else if (keyboard.bキーが押された((int)SlimDXKeys.Key.D2) && TJAPlayer3.ConfigIni.b太鼓パートAutoPlay[0])
				{
					if (!TJAPlayer3.DTX[0].bHasBranch[TJAPlayer3.stage選曲.n確定された曲の難易度[0]]) return;

					//listBRANCHを廃止したため強制分岐の開始値を
					//rc演奏用タイマ.n現在時刻msから引っ張ることに

					//判定枠に一番近いチップの情報を元に一小節分の値を計算する. 2020.04.21 akasoko26
					var p判定枠に最も近いチップ = r指定時刻に一番近い未ヒットChipを過去方向優先で検索する((long)(CSound管理.rc演奏用タイマ.n現在時刻ms * (((double)TJAPlayer3.ConfigIni.n演奏速度) / 20.0)), 0);

					double db一小節後 = 0.0;
					if (p判定枠に最も近いチップ != null)
						db一小節後 = ((15000.0 / p判定枠に最も近いチップ.dbBPM * (p判定枠に最も近いチップ.fNow_Measure_s / p判定枠に最も近いチップ.fNow_Measure_m)) * 16.0);

					this.t分岐処理(1, 0, (CSound管理.rc演奏用タイマ.n現在時刻ms * (((double)TJAPlayer3.ConfigIni.n演奏速度) / 20.0)) + db一小節後);

					TJAPlayer3.stage演奏ドラム画面.actLaneTaiko.t分岐レイヤー_コース変化(TJAPlayer3.stage演奏ドラム画面.actLaneTaiko.stBranch[0].nAfter, 1, 0);
					TJAPlayer3.stage演奏ドラム画面.actMtaiko.tBranchEvent(TJAPlayer3.stage演奏ドラム画面.actMtaiko.After[0], 1, 0);

					this.n現在のコース[0] = 1;
					this.n次回のコース[0] = 1;
					this.nレーン用表示コース[0] = 1;

					this.b強制的に分岐させた[0] = true;
				}
				else if (keyboard.bキーが押された((int)SlimDXKeys.Key.D3) && TJAPlayer3.ConfigIni.b太鼓パートAutoPlay[0])
				{
					if (!TJAPlayer3.DTX[0].bHasBranch[TJAPlayer3.stage選曲.n確定された曲の難易度[0]]) return;

					//listBRANCHを廃止したため強制分岐の開始値を
					//rc演奏用タイマ.n現在時刻msから引っ張ることに

					//判定枠に一番近いチップの情報を元に一小節分の値を計算する. 2020.04.21 akasoko26
					var p判定枠に最も近いチップ = r指定時刻に一番近い未ヒットChipを過去方向優先で検索する((long)(CSound管理.rc演奏用タイマ.n現在時刻ms * (((double)TJAPlayer3.ConfigIni.n演奏速度) / 20.0)), 0);

					double db一小節後 = 0.0;
					if (p判定枠に最も近いチップ != null)
						db一小節後 = ((15000.0 / p判定枠に最も近いチップ.dbBPM * (p判定枠に最も近いチップ.fNow_Measure_s / p判定枠に最も近いチップ.fNow_Measure_m)) * 16.0);

					this.t分岐処理(2, 0, (CSound管理.rc演奏用タイマ.n現在時刻ms * (((double)TJAPlayer3.ConfigIni.n演奏速度) / 20.0)) + db一小節後);

					TJAPlayer3.stage演奏ドラム画面.actLaneTaiko.t分岐レイヤー_コース変化(TJAPlayer3.stage演奏ドラム画面.actLaneTaiko.stBranch[0].nAfter, 2, 0);
					TJAPlayer3.stage演奏ドラム画面.actMtaiko.tBranchEvent(TJAPlayer3.stage演奏ドラム画面.actMtaiko.After[0], 2, 0);

					this.n現在のコース[0] = 2;
					this.n次回のコース[0] = 2;
					this.nレーン用表示コース[0] = 2;

					this.b強制的に分岐させた[0] = true;
				}
				else if (keyboard.bキーが押された((int)SlimDXKeys.Key.D4) && TJAPlayer3.ConfigIni.b太鼓パートAutoPlay[1] && TJAPlayer3.ConfigIni.nPlayerCount >= 2)
				{
					if (!TJAPlayer3.DTX[1].bHasBranch[TJAPlayer3.stage選曲.n確定された曲の難易度[0]]) return;

					//listBRANCHを廃止したため強制分岐の開始値を
					//rc演奏用タイマ.n現在時刻msから引っ張ることに

					//判定枠に一番近いチップの情報を元に一小節分の値を計算する. 2020.04.21 akasoko26
					var p判定枠に最も近いチップ = r指定時刻に一番近い未ヒットChipを過去方向優先で検索する((long)(CSound管理.rc演奏用タイマ.n現在時刻ms * (((double)TJAPlayer3.ConfigIni.n演奏速度) / 20.0)), 0);

					double db一小節後 = 0.0;
					if (p判定枠に最も近いチップ != null)
						db一小節後 = ((15000.0 / p判定枠に最も近いチップ.dbBPM * (p判定枠に最も近いチップ.fNow_Measure_s / p判定枠に最も近いチップ.fNow_Measure_m)) * 16.0);

					this.t分岐処理(0, 1, (CSound管理.rc演奏用タイマ.n現在時刻ms * (((double)TJAPlayer3.ConfigIni.n演奏速度) / 20.0)) + db一小節後);

					TJAPlayer3.stage演奏ドラム画面.actLaneTaiko.t分岐レイヤー_コース変化(TJAPlayer3.stage演奏ドラム画面.actLaneTaiko.stBranch[0].nAfter, 0, 1);
					TJAPlayer3.stage演奏ドラム画面.actMtaiko.tBranchEvent(TJAPlayer3.stage演奏ドラム画面.actMtaiko.After[1], 0, 1);

					this.n現在のコース[1] = 0;
					this.n次回のコース[1] = 0;
					this.nレーン用表示コース[1] = 0;

					this.b強制的に分岐させた[1] = true;
				}
				else if (keyboard.bキーが押された((int)SlimDXKeys.Key.D5) && TJAPlayer3.ConfigIni.b太鼓パートAutoPlay[1] && TJAPlayer3.ConfigIni.nPlayerCount >= 2)
				{
					if (!TJAPlayer3.DTX[1].bHasBranch[TJAPlayer3.stage選曲.n確定された曲の難易度[0]]) return;

					//listBRANCHを廃止したため強制分岐の開始値を
					//rc演奏用タイマ.n現在時刻msから引っ張ることに

					//判定枠に一番近いチップの情報を元に一小節分の値を計算する. 2020.04.21 akasoko26
					var p判定枠に最も近いチップ = r指定時刻に一番近い未ヒットChipを過去方向優先で検索する((long)(CSound管理.rc演奏用タイマ.n現在時刻ms * (((double)TJAPlayer3.ConfigIni.n演奏速度) / 20.0)), 0);

					double db一小節後 = 0.0;
					if (p判定枠に最も近いチップ != null)
						db一小節後 = ((15000.0 / p判定枠に最も近いチップ.dbBPM * (p判定枠に最も近いチップ.fNow_Measure_s / p判定枠に最も近いチップ.fNow_Measure_m)) * 16.0);

					this.t分岐処理(1, 1, (CSound管理.rc演奏用タイマ.n現在時刻ms * (((double)TJAPlayer3.ConfigIni.n演奏速度) / 20.0)) + db一小節後);

					TJAPlayer3.stage演奏ドラム画面.actLaneTaiko.t分岐レイヤー_コース変化(TJAPlayer3.stage演奏ドラム画面.actLaneTaiko.stBranch[0].nAfter, 1, 1);
					TJAPlayer3.stage演奏ドラム画面.actMtaiko.tBranchEvent(TJAPlayer3.stage演奏ドラム画面.actMtaiko.After[1], 1, 1);

					this.n現在のコース[1] = 1;
					this.n次回のコース[1] = 1;
					this.nレーン用表示コース[1] = 1;

					this.b強制的に分岐させた[1] = true;
				}
				else if (keyboard.bキーが押された((int)SlimDXKeys.Key.D6) && TJAPlayer3.ConfigIni.b太鼓パートAutoPlay[1] && TJAPlayer3.ConfigIni.nPlayerCount >= 2)
				{
					if (!TJAPlayer3.DTX[1].bHasBranch[TJAPlayer3.stage選曲.n確定された曲の難易度[0]]) return;

					//listBRANCHを廃止したため強制分岐の開始値を
					//rc演奏用タイマ.n現在時刻msから引っ張ることに

					//判定枠に一番近いチップの情報を元に一小節分の値を計算する. 2020.04.21 akasoko26
					var p判定枠に最も近いチップ = r指定時刻に一番近い未ヒットChipを過去方向優先で検索する((long)(CSound管理.rc演奏用タイマ.n現在時刻ms * (((double)TJAPlayer3.ConfigIni.n演奏速度) / 20.0)), 0);

					double db一小節後 = 0.0;
					if (p判定枠に最も近いチップ != null)
						db一小節後 = ((15000.0 / p判定枠に最も近いチップ.dbBPM * (p判定枠に最も近いチップ.fNow_Measure_s / p判定枠に最も近いチップ.fNow_Measure_m)) * 16.0);

					this.t分岐処理(2, 1, (CSound管理.rc演奏用タイマ.n現在時刻ms * (((double)TJAPlayer3.ConfigIni.n演奏速度) / 20.0)) + db一小節後);

					TJAPlayer3.stage演奏ドラム画面.actLaneTaiko.t分岐レイヤー_コース変化(TJAPlayer3.stage演奏ドラム画面.actLaneTaiko.stBranch[0].nAfter, 2, 1);
					TJAPlayer3.stage演奏ドラム画面.actMtaiko.tBranchEvent(TJAPlayer3.stage演奏ドラム画面.actMtaiko.After[1], 2, 1);

					this.n現在のコース[1] = 2;
					this.n次回のコース[1] = 2;
					this.nレーン用表示コース[1] = 2;

					this.b強制的に分岐させた[1] = true;
				}
				if ( keyboard.bキーが押された( (int)SlimDXKeys.Key.F4 ) )
				{
					if( TJAPlayer3.ConfigIni.bJudgeCountDisplay == false )
						TJAPlayer3.ConfigIni.bJudgeCountDisplay = true;
					else
						TJAPlayer3.ConfigIni.bJudgeCountDisplay = false;
				}
				else if ( keyboard.bキーが押された( (int)SlimDXKeys.Key.F5 ) )
				{
					switch( TJAPlayer3.ConfigIni.eClipDispType  )
					{
						case EClipDispType.OFF:
							TJAPlayer3.ConfigIni.eClipDispType = EClipDispType.背景のみ;
							break;
						case EClipDispType.背景のみ:
							TJAPlayer3.ConfigIni.eClipDispType = EClipDispType.ウィンドウのみ;
							break;
						case EClipDispType.ウィンドウのみ:
							TJAPlayer3.ConfigIni.eClipDispType = EClipDispType.両方;
							break;
						case EClipDispType.両方:
							TJAPlayer3.ConfigIni.eClipDispType = EClipDispType.OFF;
							break;
					}
				}
				if ( keyboard.bキーが押された( (int)SlimDXKeys.Key.F6 ) )
				{
					TJAPlayer3.ConfigIni.b太鼓パートAutoPlay[0] = !TJAPlayer3.ConfigIni.b太鼓パートAutoPlay[0];
					this.b途中でAutoを切り替えたか[0] = true;
				}
				if ( keyboard.bキーが押された( (int)SlimDXKeys.Key.F7 ) )
				{
					TJAPlayer3.ConfigIni.b太鼓パートAutoPlay[1] = !TJAPlayer3.ConfigIni.b太鼓パートAutoPlay[1];
					this.b途中でAutoを切り替えたか[1] = true;
				}
			}
			if( !this.actPauseMenu.bIsActivePopupMenu && this.bPAUSE && ( ( base.eフェーズID != CStage.Eフェーズ.演奏_STAGE_FAILED ) ) && ( base.eフェーズID != CStage.Eフェーズ.演奏_STAGE_FAILED_フェードアウト ) )
			{
				if ( keyboard.bキーが押された( (int)SlimDXKeys.Key.Delete ) )
				{	// del (debug info)
					TJAPlayer3.ConfigIni.b演奏情報を表示する = !TJAPlayer3.ConfigIni.b演奏情報を表示する;
				}
				else if ((keyboard.bキーが押された((int)SlimDXKeys.Key.Escape)))
				{   // escape (exit)
					CSound管理.rc演奏用タイマ.t再開();
					TJAPlayer3.Timer.t再開();
					this.t演奏中止();
				}
			}

#region [ Minus & Equals Sound Group Level ]
			KeyboardSoundGroupLevelControlHandler.Handle(
				keyboard, TJAPlayer3.SoundGroupLevelController, TJAPlayer3.Skin, false);
#endregion
		}

		protected void t入力メソッド記憶()
		{
			if ( TJAPlayer3.Pad.st検知したデバイス.Keyboard )
			{
				this.b演奏にキーボードを使った = true;
			}
			if ( TJAPlayer3.Pad.st検知したデバイス.Joypad )
			{
				this.b演奏にジョイパッドを使った = true;
			}
			if ( TJAPlayer3.Pad.st検知したデバイス.MIDIIN )
			{
				this.b演奏にMIDI入力を使った = true;
			}
			if ( TJAPlayer3.Pad.st検知したデバイス.Mouse )
			{
				this.b演奏にマウスを使った = true;
			}
		}

		protected virtual void t進行描画_AVI()
		{
			if ( ( ( base.eフェーズID != CStage.Eフェーズ.演奏_STAGE_FAILED ) && ( base.eフェーズID != CStage.Eフェーズ.演奏_STAGE_FAILED_フェードアウト ) ) && ( !TJAPlayer3.ConfigIni.bストイックモード && TJAPlayer3.ConfigIni.bAVI有効 ) )
			{
				this.actAVI.t進行描画();
			}
		}
		protected void t進行描画_STAGEFAILED()
		{
			if ( ( ( base.eフェーズID == CStage.Eフェーズ.演奏_STAGE_FAILED ) || ( base.eフェーズID == CStage.Eフェーズ.演奏_STAGE_FAILED_フェードアウト ) ) && ( ( this.actStageFailed.On進行描画() != 0 ) && ( base.eフェーズID != CStage.Eフェーズ.演奏_STAGE_FAILED_フェードアウト ) ) )
			{
				this.eフェードアウト完了時の戻り値 = E演奏画面の戻り値.ステージ失敗;
				base.eフェーズID = CStage.Eフェーズ.演奏_STAGE_FAILED_フェードアウト;
				this.actFO.tフェードアウト開始();
			}
		}

		protected void t進行描画_パネル文字列()
		{
			if ( ( base.eフェーズID != CStage.Eフェーズ.演奏_STAGE_FAILED ) && ( base.eフェーズID != CStage.Eフェーズ.演奏_STAGE_FAILED_フェードアウト ) )
			{
				this.actPanel.t進行描画();
			}
		}
		protected void tパネル文字列の設定()
		{
			// When performing calibration, inform the player that
			// calibration is taking place, rather than
			// displaying the panel title or song title as usual.

			var panelString = TJAPlayer3.IsPerformingCalibration
				? "Calibrating input..."
				: string.IsNullOrEmpty( TJAPlayer3.DTX[0].PANEL ) ? TJAPlayer3.DTX[0].TITLE: TJAPlayer3.DTX[0].PANEL;

			string subtitle = TJAPlayer3.DTX[0].SUBTITLEDisp ? TJAPlayer3.DTX[0].SUBTITLE : null;

			this.actPanel.SetPanelString(panelString, subtitle, TJAPlayer3.stage選曲.str確定された曲のジャンル, TJAPlayer3.Skin.Game_StageText);
		}


		protected void t進行描画_ゲージ()
		{
			if ( ( ( ( base.eフェーズID != CStage.Eフェーズ.演奏_STAGE_FAILED ) && ( base.eフェーズID != CStage.Eフェーズ.演奏_STAGE_FAILED_フェードアウト ) ) ) )
			{
				this.actGauge.On進行描画();
			}
		}
		protected void t進行描画_コンボ()
		{
			this.actCombo.On進行描画();
		}
		protected void t進行描画_スコア()
		{
			this.actScore.On進行描画();
		}
		protected bool t進行描画_チップ( int nPlayer )
		{
			if ( ( base.eフェーズID == CStage.Eフェーズ.演奏_STAGE_FAILED ) || ( base.eフェーズID == CStage.Eフェーズ.演奏_STAGE_FAILED_フェードアウト ) )
			{
				return true;
			}
			if ( ( this.n現在のトップChip == -1 ) || ( this.n現在のトップChip >= listChip[ nPlayer ].Count ) )
			{
				return true;
			}
			if (IsDanFailed)
			{
				return true;
			}

			var n現在時刻ms = (long)(CSound管理.rc演奏用タイマ.n現在時刻ms * (((double)TJAPlayer3.ConfigIni.n演奏速度) / 20.0));

			if( this.r指定時刻に一番近い未ヒットChip( (long)n現在時刻ms, 0x50, 0, 1000000, nPlayer ) == null )
			{
				this.actChara.b演奏中 = false;
			}

			CConfigIni configIni = TJAPlayer3.ConfigIni;

			CDTX dTX = TJAPlayer3.DTX[nPlayer];
			bool bAutoPlay = configIni.b太鼓パートAutoPlay[nPlayer];

			if( this.n分岐した回数[ nPlayer ] == 0 )
			{
				this.bUseBranch[ nPlayer ] = dTX.bHIDDENBRANCH ? false : dTX.bHasBranchChip;
			}


			//CDTXMania.act文字コンソール.tPrint(0, 0, C文字コンソール.Eフォント種別.灰, this.nLoopCount_Clear.ToString()  );

			float? play_bpm_time = null;

			//for ( int nCurrentTopChip = this.n現在のトップChip; nCurrentTopChip < dTX.listChip.Count; nCurrentTopChip++ )
			for ( int nCurrentTopChip = dTX.listChip.Count - 1; nCurrentTopChip > 0; nCurrentTopChip-- )
			{
				CDTX.CChip pChip = dTX.listChip[ nCurrentTopChip ];
//Debug.WriteLine( "nCurrentTopChip=" + nCurrentTopChip + ", ch=" + pChip.nチャンネル番号.ToString("x2") + ", 発音位置=" + pChip.n発声位置 + ", 発声時刻ms=" + pChip.n発声時刻ms );
				var time = pChip.n発声時刻ms - n現在時刻ms;
				pChip.nバーからの距離dot.Drums = (int) ( time );
				pChip.nバーからの距離dot.Taiko = (int) ( time * pChip.dbBPM * pChip.dbSCROLL * (this.act譜面スクロール速度.db現在の譜面スクロール速度[nPlayer] + 1.0 )  / 502.8594 / 5.0 );//2020.04.18 Mr-Ojii rhimm様のコードを参考にばいそくの計算を修正
				if( pChip.nノーツ終了時刻ms != 0 )
					pChip.nバーからのノーツ末端距離dot = (int) (  ( pChip.nノーツ終了時刻ms - n現在時刻ms) * pChip.db末端BPM * pChip.db末端SCROLL * (this.act譜面スクロール速度.db現在の譜面スクロール速度[nPlayer] + 1.0 )  / 502.8594 / 5.0);// 2020.04.18 Mr-Ojii rhimm様のコードを参考にばいそくの計算の修正

				if ( configIni.eScrollMode == EScrollMode.BMSCROLL || configIni.eScrollMode == EScrollMode.HBSCROLL )
				{
					if( !play_bpm_time.HasValue )
					{
						play_bpm_time = this.GetNowPBMTime( dTX );
					}

					var dbSCROLL = configIni.eScrollMode == EScrollMode.BMSCROLL ? 1.0 : pChip.dbSCROLL;

					pChip.nバーからの距離dot.Taiko = (int)(3 * 0.8335 * ( ( pChip.fBMSCROLLTime * NOTE_GAP ) - ( play_bpm_time * NOTE_GAP ) ) * dbSCROLL * (this.act譜面スクロール速度.db現在の譜面スクロール速度[nPlayer] + 1.0 ) / 2  / 5.0);// 2020.04.18 Mr-Ojii rhimm様のコードを参考にばいそくの計算の修正

					if ( pChip.nノーツ終了時刻ms != 0 )
						pChip.nバーからのノーツ末端距離dot = (int)( 3 * 0.8335 *( ( pChip.fBMSCROLLTime_end * NOTE_GAP) - ( play_bpm_time * NOTE_GAP ) ) * pChip.db末端SCROLL * (this.act譜面スクロール速度.db現在の譜面スクロール速度[nPlayer] + 1.0 ) / 2 /5.0);// 2020.04.20 Mr-Ojii rhimm様のコードを参考にばいそくの計算の修正
				}
				else if(configIni.eScrollMode == EScrollMode.REGULSPEED) 
				{
					pChip.nバーからの距離dot.Taiko = (int)(time * TJAPlayer3.ConfigIni.nRegSpeedBPM * (this.act譜面スクロール速度.db現在の譜面スクロール速度[nPlayer] + 1.0) / 502.8594 / 5.0);//2020.04.18 Mr-Ojii rhimm様のコードを参考にばいそくの計算を修正
					if (pChip.nノーツ終了時刻ms != 0)
						pChip.nバーからのノーツ末端距離dot = (int)((pChip.nノーツ終了時刻ms - n現在時刻ms) * TJAPlayer3.ConfigIni.nRegSpeedBPM * (this.act譜面スクロール速度.db現在の譜面スクロール速度[nPlayer] + 1.0) / 502.8594 / 5.0);// 2020.04.18 Mr-Ojii rhimm様のコードを参考にばいそくの計算の修正
				}

				if (!pChip.IsMissed && !pChip.bHit)//2020.04.25 Mr-Ojii akasoko26さんのコードをもとに変更
				{
					if (pChip.nチャンネル番号 >= 0x11 && pChip.nチャンネル番号 <= 0x14 || pChip.nチャンネル番号 == 0x1A || pChip.nチャンネル番号 == 0x1B)//|| pChip.nチャンネル番号 == 0x9A )
					{
						//こっちのほうが適格と考えたためフラグを変更.2020.04.20 Akasoko26
						if (time <= 0)
						{
							if (this.e指定時刻からChipのJUDGEを返す(n現在時刻ms, pChip) == E判定.Miss)
							{
								pChip.IsMissed = true;
								pChip.eNoteState = ENoteState.bad;
								this.tチップのヒット処理(n現在時刻ms, pChip, false, 0, nPlayer);
							}
						}
					}
				}

				if ( pChip.nバーからの距離dot[(int)pChip.e楽器パート] < -150 )
				{
					if( !( pChip.nチャンネル番号 >= 0x11 && pChip.nチャンネル番号 <= 0x14 ) || pChip.nチャンネル番号 == 0x1A || pChip.nチャンネル番号 == 0x1B )
					{
						//2016.02.11 kairera0467
						//太鼓の単音符の場合は座標による判定を行わない。
						//(ここで判定をすると高スピードでスクロールしている時に見逃し不可判定が行われない。)
						pChip.bHit = true;
					}
				}

				var cChipCurrentlyInProcess = chip現在処理中の連打チップ[ nPlayer ];
				if( cChipCurrentlyInProcess != null && !cChipCurrentlyInProcess.bHit )
				{
					if( cChipCurrentlyInProcess.nチャンネル番号 >= 0x13 && cChipCurrentlyInProcess.nチャンネル番号 <= 0x15 )//|| pChip.nチャンネル番号 == 0x9A )
					{
						if ( ( ( cChipCurrentlyInProcess.nバーからの距離dot.Taiko < -500 ) && ( cChipCurrentlyInProcess.n発声時刻ms <= n現在時刻ms && cChipCurrentlyInProcess.nノーツ終了時刻ms >= n現在時刻ms ) ) )
						   //( ( chip現在処理中の連打チップ.nバーからのノーツ末端距離dot.Taiko < -500 ) && ( chip現在処理中の連打チップ.n発声時刻ms <= CSound管理.rc演奏用タイマ.n現在時刻ms && chip現在処理中の連打チップ.nノーツ終了時刻ms >= CSound管理.rc演奏用タイマ.n現在時刻ms ) ) )
						   //( ( pChip.n発声時刻ms <= CSound管理.rc演奏用タイマ.n現在時刻ms && pChip.nノーツ終了時刻ms >= CSound管理.rc演奏用タイマ.n現在時刻ms ) ) )
						{
							if( bAutoPlay )
								this.tチップのヒット処理( n現在時刻ms, cChipCurrentlyInProcess, false, 0, nPlayer );
						}
					}
				}

				//if((!pChip.bHit || pChip.bShow) && (pChip.nバーからの距離dot.Drums < 0))
				//{
				//    NowProcessingChip[pChip.nPlayerSide] = nCurrentTopChip;
				//}

				if(pChip.nPlayerSide == nPlayer && pChip.n発声時刻ms >= n現在時刻ms)
				{
					NowProcessingChip[pChip.nPlayerSide] = nCurrentTopChip;
				}
				
				switch ( pChip.nチャンネル番号 )
				{
#region [ 01: BGM ]
					case 0x01:	// BGM
						if ( !pChip.bHit && ( pChip.nバーからの距離dot.Drums < 0 ) )
						{
							pChip.bHit = true;
							if ( configIni.bBGM音を発声する )
							{
								dTX.tチップの再生( pChip, CSound管理.rc演奏用タイマ.n前回リセットした時のシステム時刻ms + (long)(pChip.n発声時刻ms / (((double)TJAPlayer3.ConfigIni.n演奏速度) / 20.0)));
							}
						}
						break;
#endregion
#region [ 03: BPM変更 ]
					case 0x03:	// BPM変更
						if ( !pChip.bHit && ( pChip.nバーからの距離dot.Drums < 0 ) )
						{
							pChip.bHit = true;
							this.actPlayInfo.dbBPM = dTX.BASEBPM; //2016.07.10 kairera0467 太鼓の仕様にあわせて修正。(そもそもの仕様が不明&コードミス疑惑)
						}
						break;
#endregion
#region [ 04, 07: EmptySlot ]
					case 0x04:
					case 0x07:
						break;
#endregion
#region [ 08: BPM変更(拡張) ]
					case 0x08:	// BPM変更(拡張)
						//CDTXMania.act文字コンソール.tPrint( 414 + pChip.nバーからの距離dot.Drums + 4, 192, C文字コンソール.Eフォント種別.白, "BRANCH START" + "  " + pChip.n整数値.ToString() );
						if ( !pChip.bHit && ( pChip.nバーからの距離dot.Drums < 0 ) )
						{
							pChip.bHit = true;
							//if( pChip.nコース == this.n現在のコース[ nPlayer ] )
							//{
								//if ( dTX.listBPM.ContainsKey( pChip.n整数値_内部番号 ) )
								//{
									//this.actPlayInfo.dbBPM = ( dTX.listBPM[ pChip.n整数値_内部番号 ].dbBPM値 * ( ( (double) configIni.n演奏速度 ) / 20.0 ) );// + dTX.BASEBPM;
								//}
								//double bpm = ( dTX.listBPM[ pChip.n整数値_内部番号 ].dbBPM値 * ( ( (double) configIni.n演奏速度 ) / 20.0 ) );
								//int nUnit = (int)((60.0 / ( bpm ) / this.actChara.nキャラクター通常モーション枚数 ) * 1000 );
								//int nUnit_gogo = (int)((60.0 / ( bpm ) / this.actChara.nキャラクターゴーゴーモーション枚数 ) * 1000 );
								//this.actChara.ct通常モーション = new CCounter( 0, this.actChara.nキャラクター通常モーション枚数 - 1, nUnit, CDTXMania.Timer );
								//this.actChara.ctゴーゴーモーション = new CCounter(0, this.actChara.nキャラクターゴーゴーモーション枚数 - 1, nUnit_gogo * 2, CDTXMania.Timer);

							//}
						}
						break;
#endregion

#region [ 11-1f: 太鼓1P ]
					case 0x11:
					case 0x12:
					case 0x13:
					case 0x14:
						{
							this.t進行描画_チップ_Taiko( configIni, ref dTX, ref pChip, nPlayer );
						}
						break;

					case 0x15:
					case 0x16:
					case 0x17:
						{
							//2015.03.28 kairera0467
							//描画順序を変えるため、メイン処理だけをこちらに残して描画処理は分離。

							//this.t進行描画_チップ_Taiko連打(configIni, ref dTX, ref pChip);
							//2015.04.13 kairera0467 ここを外さないと恋文2000の連打に対応できず、ここをつけないと他のコースと重なっている連打をどうにもできない。
							//常時実行メソッドに渡したら対応できた!?
							//if ((!pChip.bHit && (pChip.nバーからの距離dot.Drums < 0)))
							{
								if( ( pChip.n発声時刻ms <= (int)n現在時刻ms && pChip.nノーツ終了時刻ms >= (int)n現在時刻ms ) )
								{
									//if( this.n現在のコース == pChip.nコース )
									if( pChip.b可視 == true )
										this.chip現在処理中の連打チップ[ nPlayer ] = pChip;
								}
							}
							if (pChip.n描画優先度 <= 0)
								this.t進行描画_チップ_Taiko連打(configIni, ref dTX, ref pChip, nPlayer);
						}

						break;
					case 0x18:
						{
							if( ( !pChip.bHit && (pChip.nバーからの距離dot.Drums < 0 ) ) )
							{
								this.b連打中[ nPlayer ] = false;
								this.actRoll.b表示[ nPlayer ] = false;
								this.actChara.b風船連打中[nPlayer] = false;
								pChip.bHit = true;
								if( chip現在処理中の連打チップ[ nPlayer ] != null )
								{
									chip現在処理中の連打チップ[ nPlayer ].bHit = true;
									chip現在処理中の連打チップ[nPlayer].bShow = true;
									if (chip現在処理中の連打チップ[nPlayer].nBalloon > chip現在処理中の連打チップ[nPlayer].nRollCount && chip現在処理中の連打チップ[nPlayer].nRollCount > 0 && actChara.CharaAction_Balloon_Miss != null)
									{
										if (TJAPlayer3.Skin.Game_Chara_Ptn_Balloon_Miss[nPlayer] > 0)
										{
											actChara.アクションタイマーリセット(nPlayer);
											actChara.bマイどんアクション中[nPlayer] = true;
											actChara.CharaAction_Balloon_Miss[nPlayer] = new CCounter(0, TJAPlayer3.Skin.Game_Chara_Ptn_Balloon_Miss[nPlayer] - 1, TJAPlayer3.Skin.Game_Chara_Balloon_Timer[nPlayer], TJAPlayer3.Timer);
											if (actChara.CharaAction_Balloon_Delay[nPlayer] != null) actChara.CharaAction_Balloon_Delay[nPlayer] = new CCounter(0, TJAPlayer3.Skin.Game_Chara_Balloon_Delay[nPlayer] - 1, 1, TJAPlayer3.Timer);
										}
									}
									chip現在処理中の連打チップ[nPlayer] = null;

								}
								this.eRollState = E連打State.none;
							}
							if( pChip.n描画優先度 <= 0 )
								this.t進行描画_チップ_Taiko連打(configIni, ref dTX, ref pChip, nPlayer);
						}

						break;
					case 0x19:
					case 0x1c:
					case 0x1d:
					case 0x1e:
						break;

					case 0x1a:
					case 0x1b:
					case 0x1f:
						{
							this.t進行描画_チップ_Taiko( configIni, ref dTX, ref pChip, nPlayer );
						}
						break;
#endregion
#region [ 20-2F: EmptySlot ]
					case 0x20:
					case 0x21:
					case 0x22:
					case 0x23:
					case 0x24:
					case 0x25:
					case 0x26:
					case 0x27:
					case 0x28:
					case 0x29:
					case 0x2a:
					case 0x2b:
					case 0x2c:
					case 0x2d:
					case 0x2e:
					case 0x2f:
						break;
#endregion
#region [ 31-3f: EmptySlot ]
					case 0x31:
					case 0x32:
					case 0x33:
					case 0x34:
					case 0x35:
					case 0x36:
					case 0x37:
					case 0x38:
					case 0x39:
					case 0x3a:
					case 0x3b:
					case 0x3c:
					case 0x3d:
					case 0x3e:
					case 0x3f:
						break;
#endregion

#region [ 50: 小節線 ]
					case 0x50:	// 小節線
						{
							if ( !pChip.bHit && ( pChip.nバーからの距離dot.Drums < 0 ) )
							{
								this.actChara.b演奏中 = true;
								if( this.actPlayInfo.NowMeasure[nPlayer] == 0 )
								{
									for (int i = 0; i < 2; i++)
									{ 
										   ctChipAnime[i] = new CCounter(0, 3, 60.0 / TJAPlayer3.stage演奏ドラム画面.actPlayInfo.dbBPM * 1 / 4 / (((double)TJAPlayer3.ConfigIni.n演奏速度) / 20.0), CSound管理.rc演奏用タイマ);
									}

									if (TJAPlayer3.Skin.Game_Chara_Ptn_Normal[nPlayer] != 0)
									{
										double dbPtn_Normal = (60.0 / TJAPlayer3.stage演奏ドラム画面.actPlayInfo.dbBPM) * TJAPlayer3.Skin.Game_Chara_Beat_Normal[nPlayer] / this.actChara.arモーション番号[nPlayer].Length / (((double)TJAPlayer3.ConfigIni.n演奏速度) / 20.0);
										this.actChara.ctChara_Normal[nPlayer] = new CCounter(0, this.actChara.arモーション番号[nPlayer].Length - 1, dbPtn_Normal, CSound管理.rc演奏用タイマ);
									}
									else
									{
										this.actChara.ctChara_Normal[nPlayer] = new CCounter();
									}
									if (TJAPlayer3.Skin.Game_Chara_Ptn_Clear[nPlayer] != 0)
									{
										double dbPtn_Clear = (60.0 / TJAPlayer3.stage演奏ドラム画面.actPlayInfo.dbBPM) * TJAPlayer3.Skin.Game_Chara_Beat_Clear[nPlayer] / this.actChara.arクリアモーション番号[nPlayer].Length / (((double)TJAPlayer3.ConfigIni.n演奏速度) / 20.0);
										this.actChara.ctChara_Clear[nPlayer] = new CCounter(0, this.actChara.arクリアモーション番号[nPlayer].Length - 1, dbPtn_Clear, CSound管理.rc演奏用タイマ);
									}
									else
									{
										this.actChara.ctChara_Clear[nPlayer] = new CCounter();
									}
									if (TJAPlayer3.Skin.Game_Chara_Ptn_GoGo[nPlayer] != 0)
									{
										double dbPtn_GoGo = (60.0 / TJAPlayer3.stage演奏ドラム画面.actPlayInfo.dbBPM) * TJAPlayer3.Skin.Game_Chara_Beat_GoGo[nPlayer] / this.actChara.arゴーゴーモーション番号[nPlayer].Length / (((double)TJAPlayer3.ConfigIni.n演奏速度) / 20.0);
										this.actChara.ctChara_GoGo[nPlayer] = new CCounter(0, this.actChara.arゴーゴーモーション番号[nPlayer].Length - 1, dbPtn_GoGo, CSound管理.rc演奏用タイマ);
									}
									else
									{
										this.actChara.ctChara_GoGo[nPlayer] = new CCounter();
									}
									if (TJAPlayer3.Skin.Game_Dancer_Ptn != 0)
									{
										double dbUnit_dancer = (((60 / (TJAPlayer3.stage演奏ドラム画面.actPlayInfo.dbBPM))) / this.actDancer.ar踊り子モーション番号.Length) / (((double)TJAPlayer3.ConfigIni.n演奏速度) / 20.0);
										this.actDancer.ct踊り子モーション = new CCounter(0, this.actDancer.ar踊り子モーション番号.Length - 1, dbUnit_dancer * TJAPlayer3.Skin.Game_Dancer_Beat, CSound管理.rc演奏用タイマ);
									}
									else
									{
										this.actDancer.ct踊り子モーション = new CCounter();
									}
									if (TJAPlayer3.Skin.Game_Mob_Ptn != 0 && TJAPlayer3.Skin.Game_Mob_Beat > 0 ) //2018.6.15 Game_Mob_Beatが0のままCCounter生成をされて無限ループが発生しないよう対策
									{
										this.actMob.ctMob = new CCounter(1, 180, 60.0 / TJAPlayer3.stage演奏ドラム画面.actPlayInfo.dbBPM * TJAPlayer3.Skin.Game_Mob_Beat / 180 / (((double)TJAPlayer3.ConfigIni.n演奏速度) / 20.0), CSound管理.rc演奏用タイマ);
										this.actMob.ctMobPtn = new CCounter(0, TJAPlayer3.Skin.Game_Mob_Ptn - 1, 60.0 / TJAPlayer3.stage演奏ドラム画面.actPlayInfo.dbBPM * TJAPlayer3.Skin.Game_Mob_Ptn_Beat / TJAPlayer3.Skin.Game_Mob_Ptn / (((double)TJAPlayer3.ConfigIni.n演奏速度) / 20.0), CSound管理.rc演奏用タイマ);
									}
									else
									{
										this.actMob.ctMob = new CCounter();
										this.actMob.ctMobPtn = new CCounter();
									}
									TJAPlayer3.stage演奏ドラム画面.PuchiChara.ChangeBPM(60.0 / TJAPlayer3.stage演奏ドラム画面.actPlayInfo.dbBPM / (((double)TJAPlayer3.ConfigIni.n演奏速度) / 20.0));
								}
								if (!bPAUSE)//2020.07.08 Mr-Ojii KabanFriends氏のコードを参考に
								{
									actPlayInfo.NowMeasure[nPlayer] = pChip.n整数値_内部番号;
								}
								pChip.bHit = true;
							}
							this.t進行描画_チップ_小節線( configIni, ref dTX, ref pChip, nPlayer );
							break;
						}
#endregion
#region [ 51: 拍線 ]
					case 0x51:	// 拍線
						if ( !pChip.bHit && ( pChip.nバーからの距離dot.Drums < 0 ) )
						{
							pChip.bHit = true;
						}
						//太鼓では拍線を使わない。
						//this.txチップ.t2D描画( CDTXMania.app.Device, 295, configIni.bReverse.Drums ? ( ( 0x38 + pChip.nバーからの距離dot.Drums ) - 1 ) : ( ( 567 - pChip.nバーからの距離dot.Drums ) - 1 ), new Rectangle( 0, 772, 559, 2 ) );

						//this.t進行描画_チップ_小節線( configIni, ref dTX, ref pChip );
						break;
#endregion
#region [ 54: 動画再生 ]
					case 0x54:  // 動画再生
						if (!pChip.bHit && (pChip.nバーからの距離dot.Drums < 0) && pChip.nPlayerSide == 0)
						{
							pChip.bHit = true;
							if ( configIni.bAVI有効 )
							{
								switch ( pChip.eAVI種別 )
								{
									case EAVI種別.AVI:
										this.actAVI.Start( pChip.nチャンネル番号, pChip.rVD );
										break;
								}
							}
						}
						break;
#endregion
#region[ 55-60: EmptySlot ]
					case 0x55:
					case 0x56:
					case 0x57:
					case 0x58:
					case 0x59:
						break;
#endregion
#region [ 61-89: EmptySlot ]
					case 0x60:
					case 0x61:
					case 0x62:
					case 0x63:
					case 0x64:
					case 0x65:
					case 0x66:
					case 0x67:
					case 0x68:
					case 0x69:
					case 0x70:
					case 0x71:
					case 0x72:
					case 0x73:
					case 0x74:
					case 0x75:
					case 0x76:
					case 0x77:
					case 0x78:
					case 0x79:
					case 0x80:
					case 0x81:
					case 0x82:
					case 0x83:
					case 0x84:
					case 0x85:
					case 0x86:
					case 0x87:
					case 0x88:
					case 0x89:
						break;
#endregion

#region[ 90-9A: EmptySlot ]
					case 0x90:
					case 0x91:
					case 0x92:
					case 0x93:
					case 0x94:
					case 0x95:
					case 0x96:
					case 0x97:
					case 0x98:
					case 0x99:
					case 0x9A:
						break;
#endregion

#region[ 9B-9F: 太鼓 ]
					case 0x9B:
						// 段位認定モードの幕アニメーション
						if ( !pChip.bHit && ( pChip.nバーからの距離dot.Drums < 0) && pChip.nPlayerSide == 0 )
						{
							pChip.bHit = true;
							this.actPanel.t歌詞テクスチャを削除する();
							if (pChip.nコース == this.n現在のコース[nPlayer])
							{
								if (this.actDan.GetFailedAllChallenges())
								{
									this.n現在のトップChip = TJAPlayer3.DTX[0].listChip.Count - 1;	// 終端にシーク
									IsDanFailed = true;
									return true;
								}
								this.actDan.Start(this.ListDan_Number);
								ListDan_Number++;
							}
						}
						break;
					//0x9C BPM変化(アニメーション用)
					case 0x9C:
						if ( !pChip.bHit && ( pChip.nバーからの距離dot.Drums < 0 ) )
						{
							pChip.bHit = true;
							if( pChip.nコース == this.n現在のコース[ nPlayer ] )
							{
								if ( dTX.listBPM.TryGetValue( pChip.n整数値_内部番号, out CDTX.CBPM cBPM ) )
								{
									this.actPlayInfo.dbBPM = cBPM.dbBPM値;// + dTX.BASEBPM;
								}

								for (int i = 0; i < 2; i++)
								{
									double db値 = ctChipAnime[i].db現在の値;
									ctChipAnime[i] = new CCounter(0, 3, 60.0 / TJAPlayer3.stage演奏ドラム画面.actPlayInfo.dbBPM * 1 / 4 / (((double)TJAPlayer3.ConfigIni.n演奏速度) / 20.0), CSound管理.rc演奏用タイマ);
									this.ctChipAnime[i].t時間Resetdb();
									this.ctChipAnime[i].db現在の値 = db値;
								}

								if (TJAPlayer3.Skin.Game_Chara_Ptn_Normal[nPlayer] != 0)
								{
									double dbPtn_Normal = (60.0 / TJAPlayer3.stage演奏ドラム画面.actPlayInfo.dbBPM) * TJAPlayer3.Skin.Game_Chara_Beat_Normal[nPlayer] / this.actChara.arモーション番号[nPlayer].Length / (((double)TJAPlayer3.ConfigIni.n演奏速度) / 20.0);
									double db値 = this.actChara.ctChara_Normal[nPlayer].db現在の値;
									this.actChara.ctChara_Normal[nPlayer] = new CCounter(0, this.actChara.arモーション番号[nPlayer].Length - 1, dbPtn_Normal, CSound管理.rc演奏用タイマ);
									this.actChara.ctChara_Normal[nPlayer].t時間Resetdb();
									this.actChara.ctChara_Normal[nPlayer].db現在の値 = db値;
								} else
								{
									this.actChara.ctChara_Normal[nPlayer] = new CCounter();
								}
								if (TJAPlayer3.Skin.Game_Chara_Ptn_Clear[nPlayer] != 0)
								{
									double dbPtn_Clear = (60.0 / TJAPlayer3.stage演奏ドラム画面.actPlayInfo.dbBPM) * TJAPlayer3.Skin.Game_Chara_Beat_Clear[nPlayer] / this.actChara.arクリアモーション番号[nPlayer].Length / (((double)TJAPlayer3.ConfigIni.n演奏速度) / 20.0);
									double db値 = this.actChara.ctChara_Clear[nPlayer].db現在の値;
									this.actChara.ctChara_Clear[nPlayer] = new CCounter(0, this.actChara.arクリアモーション番号[nPlayer].Length - 1, dbPtn_Clear, CSound管理.rc演奏用タイマ);
									this.actChara.ctChara_Clear[nPlayer].t時間Resetdb();
									this.actChara.ctChara_Clear[nPlayer].db現在の値 = db値;
								}
								else
								{
									this.actChara.ctChara_Clear[nPlayer] = new CCounter();
								}
								if (TJAPlayer3.Skin.Game_Chara_Ptn_GoGo[nPlayer] != 0)
								{
									double dbPtn_GoGo = (60.0 / TJAPlayer3.stage演奏ドラム画面.actPlayInfo.dbBPM) * TJAPlayer3.Skin.Game_Chara_Beat_GoGo[nPlayer] / this.actChara.arゴーゴーモーション番号[nPlayer].Length / (((double)TJAPlayer3.ConfigIni.n演奏速度) / 20.0);
									double db値 = this.actChara.ctChara_GoGo[nPlayer].db現在の値;
									this.actChara.ctChara_GoGo[nPlayer] = new CCounter(0, this.actChara.arゴーゴーモーション番号[nPlayer].Length - 1, dbPtn_GoGo, CSound管理.rc演奏用タイマ);
									this.actChara.ctChara_GoGo[nPlayer].t時間Resetdb();
									this.actChara.ctChara_GoGo[nPlayer].db現在の値 = db値;
								} else
								{
									this.actChara.ctChara_GoGo[nPlayer] = new CCounter();
								}
								if (TJAPlayer3.Skin.Game_Dancer_Ptn != 0)
								{
									double dbUnit_dancer = (((60 / (TJAPlayer3.stage演奏ドラム画面.actPlayInfo.dbBPM))) / this.actDancer.ar踊り子モーション番号.Length) / (((double)TJAPlayer3.ConfigIni.n演奏速度) / 20.0);
									double db値 = this.actDancer.ct踊り子モーション.db現在の値;
									this.actDancer.ct踊り子モーション = new CCounter(0, this.actDancer.ar踊り子モーション番号.Length - 1, dbUnit_dancer * TJAPlayer3.Skin.Game_Dancer_Beat, CSound管理.rc演奏用タイマ);
									this.actDancer.ct踊り子モーション.t時間Resetdb();
									this.actDancer.ct踊り子モーション.db現在の値 = db値;
								}
								else
								{
									this.actDancer.ct踊り子モーション = new CCounter();
								}
								if (TJAPlayer3.Skin.Game_Mob_Ptn != 0)
								{
									double db値 = this.actMob.ctMob.db現在の値;
									this.actMob.ctMob = new CCounter(1, 180, 60.0 / TJAPlayer3.stage演奏ドラム画面.actPlayInfo.dbBPM * TJAPlayer3.Skin.Game_Mob_Beat / 180 / (((double)TJAPlayer3.ConfigIni.n演奏速度) / 20.0), CSound管理.rc演奏用タイマ);
									this.actMob.ctMob.t時間Resetdb();
									this.actMob.ctMob.db現在の値 = db値;

									db値 = this.actMob.ctMobPtn.db現在の値;
									this.actMob.ctMobPtn = new CCounter(0, TJAPlayer3.Skin.Game_Mob_Ptn - 1, 60.0 / TJAPlayer3.stage演奏ドラム画面.actPlayInfo.dbBPM * TJAPlayer3.Skin.Game_Mob_Ptn_Beat / TJAPlayer3.Skin.Game_Mob_Ptn / (((double)TJAPlayer3.ConfigIni.n演奏速度) / 20.0), CSound管理.rc演奏用タイマ);
									this.actMob.ctMobPtn.t時間Resetdb();
									this.actMob.ctMobPtn.db現在の値 = db値;
								} else
								{
									this.actMob.ctMob = new CCounter();
									this.actMob.ctMobPtn = new CCounter();
								}

								TJAPlayer3.stage演奏ドラム画面.PuchiChara.ChangeBPM(60.0 / TJAPlayer3.stage演奏ドラム画面.actPlayInfo.dbBPM / (((double)TJAPlayer3.ConfigIni.n演奏速度) / 20.0));
								//this.actDancer.ct踊り子モーション = new CCounter(0, this.actDancer.ar踊り子モーション番号.Length - 1, (dbUnit * CDTXMania.Skin.Game_Dancer_Beat) / this.actDancer.ar踊り子モーション番号.Length, CSound管理.rc演奏用タイマ);
								//this.actChara.ctモブモーション = new CCounter(0, this.actChara.arモブモーション番号.Length - 1, (dbUnit) / this.actChara.arモブモーション番号.Length, CSound管理.rc演奏用タイマ);
							}

						}
						break;

					case 0x9D: //SCROLL
						if ( !pChip.bHit && ( pChip.nバーからの距離dot.Drums < 0 ) )
						{
							pChip.bHit = true;
							//if ( dTX.listSCROLL.ContainsKey( pChip.n整数値_内部番号 ) )
							//{
								//this.actPlayInfo.dbBPM = ( dTX.listBPM[ pChip.n整数値_内部番号 ].dbBPM値 * ( ( (double) configIni.n演奏速度 ) / 20.0 ) );// + dTX.BASEBPM;
							//}
						}
						break;

					case 0x9E: //ゴーゴータイム
						if( !pChip.bHit && ( pChip.nバーからの距離dot.Drums < 0 ) )
						{
							pChip.bHit = true;
							this.bIsGOGOTIME[ nPlayer ] = true;
							//double dbUnit = (((60.0 / (CDTXMania.stage演奏ドラム画面.actPlayInfo.dbBPM))));
							double dbUnit = (((60.0 / pChip.dbBPM)));
							if (TJAPlayer3.Skin.Game_Chara_Ptn_GoGoStart[nPlayer] != 0 && actChara.CharaAction_Balloon_Delay[nPlayer].b終了値に達した)
							{
								if (TJAPlayer3.stage演奏ドラム画面.actGauge.db現在のゲージ値[nPlayer] < 100)
								{
									// 魂ゲージMAXではない
									// ゴーゴースタート_ノーマル
									this.actChara.アクションタイマーリセット(nPlayer);
									this.actChara.ctキャラクターアクション_ゴーゴースタート[nPlayer] = new CCounter(0, TJAPlayer3.Skin.Game_Chara_Ptn_GoGoStart[nPlayer] - 1, (dbUnit / TJAPlayer3.Skin.Game_Chara_Ptn_GoGoStart[nPlayer]) * 2, CSound管理.rc演奏用タイマ);
									this.actChara.ctキャラクターアクション_ゴーゴースタート[nPlayer].t進行db();
									this.actChara.ctキャラクターアクション_ゴーゴースタート[nPlayer].db現在の値 = 0D;
									this.actChara.bマイどんアクション中[nPlayer] = true;
									//this.actChara.マイどん_アクション_10コンボ();
								}
							}
							if (TJAPlayer3.Skin.Game_Chara_Ptn_GoGoStart_Max[nPlayer] != 0 && actChara.CharaAction_Balloon_Delay[nPlayer].b終了値に達した)
							{
								if (TJAPlayer3.stage演奏ドラム画面.actGauge.db現在のゲージ値[nPlayer] >= 100)
								{
									// 魂ゲージMAX
									// ゴーゴースタート_MAX
									this.actChara.アクションタイマーリセット(nPlayer);
									this.actChara.ctキャラクターアクション_ゴーゴースタートMAX[nPlayer] = new CCounter(0, TJAPlayer3.Skin.Game_Chara_Ptn_GoGoStart_Max[nPlayer] - 1, (dbUnit / TJAPlayer3.Skin.Game_Chara_Ptn_GoGoStart_Max[nPlayer]) * 2, CSound管理.rc演奏用タイマ);
									this.actChara.ctキャラクターアクション_ゴーゴースタートMAX[nPlayer].t進行db();
									this.actChara.ctキャラクターアクション_ゴーゴースタートMAX[nPlayer].db現在の値 = 0D;
									this.actChara.bマイどんアクション中[nPlayer] = true;
								}
							}
							TJAPlayer3.stage演奏ドラム画面.actLaneTaiko.GOGOSTART();
						}
						break;
					case 0x9F: //ゴーゴータイム
						if( !pChip.bHit && ( pChip.nバーからの距離dot.Drums < 0 ) )
						{
							pChip.bHit = true;
							this.bIsGOGOTIME[ nPlayer ] = false;
						}
						break;
#endregion

#region [ a0-a8: EmptySlot ]
					case 0xa0:
					case 0xa1:
					case 0xa2:
					case 0xa3:
					case 0xa4:
					case 0xa5:
					case 0xa6:
					case 0xa7:
					case 0xa8:
						break;
#endregion
#region [ B1～BC EmptySlot ]
					case 0xb1:
					case 0xb2:
					case 0xb3:
					case 0xb4:
					case 0xb5:
					case 0xb6:
					case 0xb7:
					case 0xb8:
					case 0xb9:
					case 0xba:
					case 0xbb:
					case 0xbc:
						break;
#endregion
#region [ c4, c7, d5-d9: EmptySlot ]
					case 0xc4:
					case 0xc7:
					case 0xd5:
					case 0xd6:	// BGA画像入れ替え
					case 0xd7:
					case 0xd8:
					case 0xd9:
					//case 0xe0:
						if ( !pChip.bHit && ( pChip.nバーからの距離dot.Drums < 0 ) )
						{
							pChip.bHit = true;
						}
						break;
#endregion

#region [ da: ミキサーへチップ音追加 ]
					case 0xDA:
						if ( !pChip.bHit && ( pChip.nバーからの距離dot.Drums < 0 ) )
						{
//Debug.WriteLine( "[DA(AddMixer)] BAR=" + pChip.n発声位置 / 384 + " ch=" + pChip.nチャンネル番号.ToString( "x2" ) + ", wav=" + pChip.n整数値.ToString( "x2" ) + ", time=" + pChip.n発声時刻ms );
							pChip.bHit = true;
							if ( listWAV.TryGetValue( pChip.n整数値_内部番号, out CDTX.CWAV wc ) )	// 参照が遠いので後日最適化する
							{
								for ( int i = 0; i < nPolyphonicSounds; i++ )
								{
									if ( wc.rSound[ i ] != null )
									{
										//CDTXMania.Sound管理.AddMixer( wc.rSound[ i ] );
										AddMixer( wc.rSound[ i ], pChip.b演奏終了後も再生が続くチップである );
									}
								}
							}
						}
						break;
#endregion
#region [ db: ミキサーからチップ音削除 ]
					case 0xDB:
						if ( !pChip.bHit && ( pChip.nバーからの距離dot.Drums < 0 ) )
						{
//Debug.WriteLine( "[DB(RemoveMixer)] BAR=" + pChip.n発声位置 / 384 + " ch=" + pChip.nチャンネル番号.ToString( "x2" ) + ", wav=" + pChip.n整数値.ToString( "x2" ) + ", time=" + pChip.n発声時刻ms );
							pChip.bHit = true;
							if ( listWAV.TryGetValue( pChip.n整数値_内部番号, out CDTX.CWAV wc ) )	// 参照が遠いので後日最適化する
							{
								for ( int i = 0; i < nPolyphonicSounds; i++ )
								{
									if ( wc.rSound[ i ] != null )
									{
										//CDTXMania.Sound管理.RemoveMixer( wc.rSound[ i ] );
										if ( !wc.rSound[ i ].b演奏終了後も再生が続くチップである )	// #32248 2013.10.16 yyagi
										{															// DTX終了後も再生が続くチップの0xDB登録をなくすことはできず。
											RemoveMixer( wc.rSound[ i ] );							// (ミキサー解除のタイミングが遅延する場合の対応が面倒なので。)
										}															// そこで、代わりにフラグをチェックしてミキサー削除ロジックへの遷移をカットする。
									}
								}
							}
						}
						break;
#endregion

#region[ dc-df:太鼓(特殊命令) ]
					case 0xDC: //DELAY
						if ( !pChip.bHit && ( pChip.nバーからの距離dot.Drums < 0 ) )
						{
							pChip.bHit = true;
							//if ( dTX.listDELAY.ContainsKey( pChip.n整数値_内部番号 ) )
							//{
								//this.actPlayInfo.dbBPM = ( dTX.listBPM[ pChip.n整数値_内部番号 ].dbBPM値 * ( ( (double) configIni.n演奏速度 ) / 20.0 ) );// + dTX.BASEBPM;
							//}
						}
						break;
					case 0xDD: //SECTION //2020.04.25 Mr-Ojii akasoko26さんのコードをもとに変更
						if (!pChip.bHit && (pChip.nバーからの距離dot.Drums < 0))
						{
							// 分岐毎にリセットしていたのでSECTIONの命令が来たらリセットする。
							this.tBranchReset(nPlayer);
							pChip.bHit = true;
						}
						break;
					case 0xDE: //Judgeに応じたCourseを取得//2020.04.25 Mr-Ojii akasoko26さんのコードをもとに変更
						if (!pChip.bHit && (pChip.nバーからの距離dot.Drums < 0))
						{
							this.b強制分岐譜面[nPlayer] = false;

							if (dTX.listBRANCH.TryGetValue(pChip.n整数値_内部番号, out CDTX.CBRANCH cBranch))
							{

								//分岐の種類はプレイヤー関係ないと思う
								this.nBranch条件数値A = cBranch.db条件数値A;
								this.nBranch条件数値B = cBranch.db条件数値B;

								if (!this.bLEVELHOLD[nPlayer])
								{
									//成仏2000にある-2,-1だったら達人に強制分岐みたいな。
									this.t強制用条件かを判断する(cBranch, nPlayer);

									TJAPlayer3.stage演奏ドラム画面.bUseBranch[nPlayer] = true;
									this.tBranchJudge(cBranch, this.CBranchScore[nPlayer].cBigNotes, this.CBranchScore[nPlayer].nScore, this.CBranchScore[nPlayer].nRoll, this.CBranchScore[nPlayer].nGreat, this.CBranchScore[nPlayer].nGood, this.CBranchScore[nPlayer].nMiss, nPlayer);

									if (this.b強制分岐譜面[nPlayer])//強制分岐譜面だったら次回コースをそのコースにセット
										this.n次回のコース[nPlayer] = this.N強制コース[nPlayer];

									this.t分岐処理(this.n次回のコース[nPlayer], nPlayer, cBranch.db分岐時刻ms, cBranch.n分岐の種類);

									TJAPlayer3.stage演奏ドラム画面.actLaneTaiko.t分岐レイヤー_コース変化(TJAPlayer3.stage演奏ドラム画面.actLaneTaiko.stBranch[nPlayer].nAfter, this.n次回のコース[nPlayer], nPlayer);
									TJAPlayer3.stage演奏ドラム画面.actMtaiko.tBranchEvent(TJAPlayer3.stage演奏ドラム画面.actMtaiko.After[nPlayer], this.n次回のコース[nPlayer], nPlayer);
									this.n現在のコース[nPlayer] = this.n次回のコース[nPlayer];
								}
								this.n分岐した回数[nPlayer]++;
							}
							pChip.bHit = true;
						}
						break;

					case 0x52://End処理
						if (!pChip.bHit && (pChip.nバーからの距離dot.Drums < 0))
						{

							pChip.bHit = true;
						}

						break;
					case 0xE0:
						//if( !pChip.bHit && ( pChip.nバーからの距離dot.Drums < 0 ) )
						//{
							//#BARLINEONと#BARLINEOFF
							//演奏中は使用しません。
						//}
						break;
					case 0xE1:
						if( !pChip.bHit && ( pChip.nバーからの距離dot.Drums < 0 ))
						{
							//LEVELHOLD
							this.bLEVELHOLD[nPlayer] = true;
						}
						break;
					case 0xE2:
						if (!pChip.bHit && (pChip.nバーからの距離dot.Drums < 0))
						{
							TJAPlayer3.stage演奏ドラム画面.actLaneTaiko.t判定枠移動(pChip.n発声時刻ms, dTX.listJPOSSCROLL[nJPOSSCROLL[nPlayer]].db移動時間, dTX.listJPOSSCROLL[nJPOSSCROLL[nPlayer]].n移動距離px, nPlayer);
							this.nJPOSSCROLL[nPlayer]++;
							pChip.bHit = true;
						}
						else if (pChip.bHit && (pChip.nバーからの距離dot.Drums > 0))
						{
							this.nJPOSSCROLL[nPlayer]--;
							TJAPlayer3.stage演奏ドラム画面.actLaneTaiko.t判定枠戻し(dTX.listJPOSSCROLL[nJPOSSCROLL[nPlayer]].n移動距離px, nPlayer);
							pChip.bHit = false;
						}
						break;
#endregion
#region[ f1: 歌詞 ]
					case 0xF1:
						if ( !pChip.bHit && ( pChip.nバーからの距離dot.Drums < 0 ) )
						{
							if( dTX.listLyric.Count > ShownLyric[nPlayer] && dTX.nPlayerSide == nPlayer )
							{
								this.actPanel.t歌詞テクスチャを生成する( dTX.listLyric[ShownLyric[nPlayer]] );
								ShownLyric[nPlayer]++;
							}
							pChip.bHit = true;
						}
						break;
#endregion
#region[ ff: 譜面の強制終了 ]
					//バグで譜面がとてつもないことになっているため、#ENDがきたらこれを差し込む。
					case 0xFF:
						if (pChip.nバーからの距離dot.Drums < 0)
						{
							if (!pChip.bHit)
							{
								if (this.bgmlength > CSound管理.rc演奏用タイマ.n現在時刻ms * ((double)TJAPlayer3.ConfigIni.n演奏速度 / 20.0))
									break;

								pChip.bHit = true;
								return true;
							}
							else
							{
								return true;
							} 
						}
						break;
#endregion

#region [ その他(未定義) ]
					default:
						if ( !pChip.bHit && ( pChip.nバーからの距離dot.Drums < 0 ) )
						{
							pChip.bHit = true;
						}
						break;
#endregion
				}

			}
			return false;
		}

		protected bool t進行描画_チップ_連打( int nPlayer )
		{
			if ( ( base.eフェーズID == CStage.Eフェーズ.演奏_STAGE_FAILED ) || ( base.eフェーズID == CStage.Eフェーズ.演奏_STAGE_FAILED_フェードアウト ) )
			{
				return true;
			}
			if ( ( this.n現在のトップChip == -1 ) || ( this.n現在のトップChip >= listChip[ nPlayer ].Count ) )
			{
				return true;
			}

			CConfigIni configIni = TJAPlayer3.ConfigIni;

			CDTX dTX = TJAPlayer3.DTX[nPlayer];

			var n現在時刻ms = (long)(CSound管理.rc演奏用タイマ.n現在時刻ms * (((double)TJAPlayer3.ConfigIni.n演奏速度) / 20.0));

			//for ( int nCurrentTopChip = this.n現在のトップChip; nCurrentTopChip < dTX.listChip.Count; nCurrentTopChip++ )
			for ( int nCurrentTopChip = dTX.listChip.Count - 1; nCurrentTopChip > 0; nCurrentTopChip-- )
			{
				CDTX.CChip pChip = dTX.listChip[ nCurrentTopChip ];

				if ( !pChip.bHit )
				{
					bool bRollChip = pChip.nチャンネル番号 >= 0x15 && pChip.nチャンネル番号 <= 0x19;
					if( bRollChip && ( ( pChip.e楽器パート != E楽器パート.UNKNOWN ) ) )
					{
						if( pChip.nバーからの距離dot[(int)pChip.e楽器パート] < -40 )
						{
							if ( this.e指定時刻からChipのJUDGEを返す( n現在時刻ms, pChip ) == E判定.Miss )
							{
								this.tチップのヒット処理( n現在時刻ms, pChip, false, 0, nPlayer );
							}
						}
					}
				}

				switch ( pChip.nチャンネル番号 )
				{
#region[ 15-19: 連打 ]
					case 0x15: //連打
					case 0x16: //連打(大)
					case 0x17: //風船
					case 0x18: //連打終了
					case 0x19:
						{
							if( pChip.n描画優先度 >= 1 )
								this.t進行描画_チップ_Taiko連打( configIni, ref dTX, ref pChip, nPlayer );
						}
						break;
#endregion
				}

			}
			return false;
		}

		public void tBranchReset(int player)
		{
			if (player >= 0)
			{
				this.CBranchScore[player].cBigNotes.nGreat = 0;
				this.CBranchScore[player].cBigNotes.nGood = 0;
				this.CBranchScore[player].cBigNotes.nMiss = 0;
				this.CBranchScore[player].cBigNotes.nRoll = 0;

				this.CBranchScore[player].nGreat = 0;
				this.CBranchScore[player].nGood = 0;
				this.CBranchScore[player].nMiss = 0;
				this.CBranchScore[player].nRoll = 0;
			}
			else
			{
				for (int i = 0; i < CBranchScore.Length; i++)
				{
					this.CBranchScore[i].cBigNotes.nGreat = 0;
					this.CBranchScore[i].cBigNotes.nGood = 0;
					this.CBranchScore[i].cBigNotes.nMiss = 0;
					this.CBranchScore[i].cBigNotes.nRoll = 0;

					this.CBranchScore[i].nGreat = 0;
					this.CBranchScore[i].nGood = 0;
					this.CBranchScore[i].nMiss = 0;
					this.CBranchScore[i].nRoll = 0;
				}
			}
		}

		//2020.04.23 Mr-Ojii akasokoさんの分岐方法を参考にして、変更
		public void tBranchJudge(CDTX.CBRANCH cBranch, CBRANCHSCORE cBRANCHSCORE, int nスコア, int n連打数, int n良, int n可, int n不可, int nPlayer)
		{
			if (this.b強制的に分岐させた[nPlayer]) return;

			int n種類 = cBranch.n分岐の種類;

			double dbRate = 0;

			if (n種類 == 0)
			{
				if ((n良 + n可 + n不可) != 0)
				{
					dbRate = (double)(n良 * 2.0 + n可) / (double)((n良 + n可 + n不可)* 2.0) * 100.0 ; //2020.05.21 Mr-Ojii 計算式変更
				}
			}
			else if (n種類 == 1)
			{
				dbRate = nスコア;
			}
			else if (n種類 == 2)
			{
				dbRate = n連打数;
			}
			else if (n種類 == 3) {
				dbRate = cBRANCHSCORE.nGreat;
			}

			if (n種類 == 0 || n種類 == 1)
			{
				if (dbRate < cBranch.db条件数値A)
				{
					this.n次回のコース[nPlayer] = 0;
					this.nレーン用表示コース[nPlayer] = 0;
				}
				else if (dbRate >= cBranch.db条件数値A && dbRate < cBranch.db条件数値B)
				{
					this.n次回のコース[nPlayer] = 1;
					this.nレーン用表示コース[nPlayer] = 1;
				}
				else if (dbRate >= cBranch.db条件数値B)
				{
					this.n次回のコース[nPlayer] = 2;
					this.nレーン用表示コース[nPlayer] = 2;
				}
			}
			else if (n種類 == 2)
			{
				if (!(cBranch.db条件数値A == 0 && cBranch.db条件数値B == 0))
				{
					if (dbRate < cBranch.db条件数値A)
					{
						this.nレーン用表示コース[nPlayer] = 0;
						this.n次回のコース[nPlayer] = 0;
					}
					else if (dbRate >= cBranch.db条件数値A && dbRate < cBranch.db条件数値B)
					{
						this.nレーン用表示コース[nPlayer] = 1;
						this.n次回のコース[nPlayer] = 1;
					}
					else if (dbRate >= cBranch.db条件数値B)
					{
						this.nレーン用表示コース[nPlayer] = 2;
						this.n次回のコース[nPlayer] = 2;
					}
				}
			}
			else if (n種類 == 3) {
				if (!(cBranch.db条件数値A == 0 && cBranch.db条件数値B == 0))
				{
					if (dbRate < cBranch.db条件数値A)
					{
						this.nレーン用表示コース[nPlayer] = 0;
						this.n次回のコース[nPlayer] = 0;
					}
					else if (dbRate >= cBranch.db条件数値A && dbRate < cBranch.db条件数値B)
					{
						this.nレーン用表示コース[nPlayer] = 1;
						this.n次回のコース[nPlayer] = 1;
					}
					else if (dbRate >= cBranch.db条件数値B)
					{
						this.nレーン用表示コース[nPlayer] = 2;
						this.n次回のコース[nPlayer] = 2;
					}
				}
			}
		}

		//2020.04.23 Mr-Ojii akasokoさんの分岐方法を参考にして、追加
		private int[] N強制コース = new int[4];
		private void t強制用条件かを判断する(CDTX.CBRANCH cBranch, int nPlayer)
		{
			double db条件A = cBranch.db条件数値A;
			double db条件B = cBranch.db条件数値B;
			int n種類 = cBranch.n分岐の種類;

			if (n種類 == 0)//精度分岐だったら
			{
				if (db条件A >= 100 && db条件B >= 100) //強制普通譜面
				{
					N強制コース[nPlayer] = 0;
					this.b強制分岐譜面[nPlayer] = true;
				}
				else if (db条件A <= 0 && db条件B >= 100)  //強制玄人譜面
				{
					N強制コース[nPlayer] = 1;
					this.b強制分岐譜面[nPlayer] = true;
				}
				else if (db条件A <= 0 && db条件B <= 0)   //強制達人譜面
				{
					N強制コース[nPlayer] = 2;
					this.b強制分岐譜面[nPlayer] = true;
				}
			}
		}

		public void t分岐処理(int n分岐先, int nPlayer, double n発声位置, int n分岐種類 = 0)//2020.04.25 Mr-Ojii akasoko26さんのコードをもとに変更
		{
			CDTX dTX = TJAPlayer3.DTX[nPlayer];

			for (int A = 0; A < dTX.listChip.Count; A++)
			{
				var Chip = dTX.listChip[A].nチャンネル番号;
				var bDontDeleteFlag = Chip >= 0x11 && Chip <= 0x19;
				var bRollAllFlag = Chip >= 0x15 && Chip <= 0x19;
				var bBalloonOnlyFlag = Chip == 0x17;
				var bRollOnlyFlag = Chip >= 0x15 && Chip <= 0x16;
				if (bDontDeleteFlag)
				{
					if (dTX.listChip[A].n発声時刻ms > n発声位置)
					{
						if (dTX.listChip[A].nコース == n分岐先)
						{
							dTX.listChip[A].b可視 = true;

							if (dTX.listChip[A].IsEndedBranching)
							{
								if (bRollAllFlag)//共通譜面時かつ、連打譜面だったら非可視化
								{
									dTX.listChip[A].bHit = true;
									dTX.listChip[A].bShow = false;
									dTX.listChip[A].b可視 = false;
								}
							}
						}
						else
						{
							dTX.listChip[A].b可視 = false;
						}
						//共通なため分岐させない.
						dTX.listChip[A].eNoteState = ENoteState.none;

						if (dTX.listChip[A].IsEndedBranching && (dTX.listChip[A].nコース == 0))
						{
							if (bRollOnlyFlag)//共通譜面時かつ、連打譜面だったら可視化
							{
								dTX.listChip[A].bHit = false;
								dTX.listChip[A].bShow = true;
								dTX.listChip[A].b可視 = true;
							}
							else
							{
								if (bBalloonOnlyFlag)//共通譜面時かつ、風船譜面だったら可視化
								{
									dTX.listChip[A].bShow = true;
									dTX.listChip[A].b可視 = true;
								}
							}
						}
					}
				}
			}
		}

		public int GetRoll(int player)
		{
			return n合計連打数[player];
		}

		protected float GetNowPBMTime( CDTX tja )
		{
			float play_time = 0;
			float bpm_time = 0;
			int last_input = 0;
			float last_bpm_change_time;
			play_time = CSound管理.rc演奏用タイマ.n現在時刻ms * (((float)TJAPlayer3.ConfigIni.n演奏速度) / 20.0f) - tja.nOFFSET;

			for (int i = 1; ; i++)
			{
				//BPMCHANGEの数越えた
				if( i >= tja.listBPM.Count )
				{
					CDTX.CBPM cBPM = tja.listBPM[ last_input ];
					bpm_time = (float)cBPM.bpm_change_bmscroll_time + ( ( play_time - (float)cBPM.bpm_change_time ) * (float)cBPM.dbBPM値 / 15000.0f );
					last_bpm_change_time = (float)cBPM.bpm_change_time;
					break;
				}
				for( ; i < tja.listBPM.Count; i++ )
				{
					CDTX.CBPM cBPM = tja.listBPM[ i ];
					if (cBPM.bpm_change_time == 0 || cBPM.bpm_change_course == this.n現在のコース[ 0 ] )
					{
						break;
					}
				}
				if( i == tja.listBPM.Count )
				{
					i = tja.listBPM.Count - 1;
					continue;
				}

				if( play_time < tja.listBPM[ i ].bpm_change_time )
				{
					CDTX.CBPM cBPM = tja.listBPM[ last_input ];
					bpm_time = (float)cBPM.bpm_change_bmscroll_time + ( ( play_time - (float)cBPM.bpm_change_time ) * (float)cBPM.dbBPM値 / 15000.0f );
					last_bpm_change_time = (float)cBPM.bpm_change_time;
					break;
				}
				else
				{
					last_input = i;
				}
			}

			return bpm_time;
		}

		public void t再読込()
		{
			TJAPlayer3.DTX[0].t全チップの再生停止とミキサーからの削除();
			this.eフェードアウト完了時の戻り値 = E演奏画面の戻り値.再読込_再演奏;
			base.eフェーズID = CStage.Eフェーズ.演奏_再読込;
			this.bPAUSE = false;
		}

		public void t演奏やりなおし()
		{
			TJAPlayer3.DTX[0].t全チップの再生停止とミキサーからの削除();
			this.t数値の初期化( true, true );
			if (TJAPlayer3.stage選曲.n確定された曲の難易度[0] == (int)Difficulty.Dan) 
			{
				TJAPlayer3.stage演奏ドラム画面.actDan.Update();
			}
			this.actPanel.t歌詞テクスチャを削除する();
			for (int i = 0; i < 2; i++)
			{
				this.t演奏位置の変更(0, i);
				this.actPlayInfo.NowMeasure[i] = 0;
			}
			TJAPlayer3.stage演奏ドラム画面.On活性化();
			for( int i = 0; i < TJAPlayer3.ConfigIni.nPlayerCount; i++ )
			{
				this.chip現在処理中の連打チップ[ i ] = null;
			}
			this.bPAUSE = false;
		}

		public void t数値の初期化( bool b演奏記録, bool b演奏状態 )
		{
			if( b演奏記録 )
			{
				for (int i = 0; i < TJAPlayer3.ConfigIni.nPlayerCount; i++)
				{
					this.nヒット数_Auto含む[i].Perfect = 0;
					this.nヒット数_Auto含む[i].Great = 0;
					this.nヒット数_Auto含む[i].Good = 0;
					this.nヒット数_Auto含む[i].Poor = 0;
					this.nヒット数_Auto含む[i].Miss = 0;

					this.nヒット数_Auto含まない[i].Perfect = 0;
					this.nヒット数_Auto含まない[i].Great = 0;
					this.nヒット数_Auto含まない[i].Good = 0;
					this.nヒット数_Auto含まない[i].Poor = 0;
					this.nヒット数_Auto含まない[i].Miss = 0;
				}

				this.actCombo.On活性化();
				this.actScore.On活性化();
				this.actGauge.Init( TJAPlayer3.ConfigIni.nRisky );
			}
			if( b演奏状態 )
			{
				for( int i = 0; i < TJAPlayer3.ConfigIni.nPlayerCount; i++ )
				{
					this.bIsGOGOTIME[ i ] = false;
					this.bLEVELHOLD[ i ] = false;
					this.b強制的に分岐させた[ i ] = false;
					this.b譜面分岐中[ i ] = false;
					this.b連打中[ i ] = false;
					this.n現在のコース[ i ] = 0;
					this.n次回のコース[ i] = 0;
					this.n現在の連打数[ i ] = 0;
					this.n合計連打数[ i ] = 0;
					this.n分岐した回数[ i ] = 0;
					this.ReSetScore(TJAPlayer3.DTX[i].nScoreInit[0, TJAPlayer3.stage選曲.n確定された曲の難易度[i]], TJAPlayer3.DTX[i].nScoreDiff[TJAPlayer3.stage選曲.n確定された曲の難易度[i]], i);
				}
				for (int i = 0; i < 2; i++)
				{
					this.actComboVoice.tReset(i);
					NowProcessingChip[i] = 0;
				}
			}

			this.nHand = new int[]{ 0, 0, 0, 0 };
		}

		public void t演奏位置の変更( int nStartBar, int nPlayer )
		{
			// まず全サウンドオフにする
			TJAPlayer3.DTX[0].t全チップの再生停止();
			this.actAVI.Stop();
			CDTX dTX = TJAPlayer3.DTX[nPlayer];

			if( dTX == null ) return; //CDTXがnullの場合はプレイヤーが居ないのでその場で処理終了


#region [ 再生開始小節の変更 ]
			//nStartBar++;									// +1が必要

#region [ 演奏済みフラグのついたChipをリセットする ]
			for ( int i = 0; i < dTX.listChip.Count; i++)//2020.04.25 Mr-Ojii akasoko26さんのコードをもとに変更
			{
				//if(dTX.listChip[i].bHit) フラグが付いてなくてもすべてのチップをリセットする。(必要がある).2020.04.23.akasoko26

				dTX.listChip[i].bHit = false;
				if (dTX.listChip[i].nチャンネル番号 != 0x50)//2020.08.01 Mr-Ojii BARLINEOFF/ONのための変更
				{
					dTX.listChip[i].bShow = true;
					dTX.listChip[i].b可視 = true;
				}
				dTX.listChip[i].IsHitted = false;
				dTX.listChip[i].IsMissed = false;
				dTX.listChip[i].eNoteState = ENoteState.none;
				dTX.listChip[i].nProcessTime = 0;
				dTX.listChip[i].nRollCount = 0;
				dTX.listChip[i].nRollCount = 0;
			}
			#endregion

			#region [ 処理を開始するチップの特定 ]
			//for ( int i = this.n現在のトップChip; i < CDTXMania.DTX.listChip.Count; i++ )
			bool bSuccessSeek = false;
			for (int i = 0; i < dTX.listChip.Count; i++)
			{
				CDTX.CChip pChip = dTX.listChip[i];
				if (nStartBar == 0)
				{
					if (pChip.n発声位置 < 384 * nStartBar)
					{
						continue;
					}
					else
					{
						bSuccessSeek = true;
						this.n現在のトップChip = i;
						break;
					}
				}
				else
				{ 
					if (pChip.nチャンネル番号 == 0x50 && pChip.n整数値_内部番号 > nStartBar - 1)
					{
						bSuccessSeek = true;
						this.n現在のトップChip = i;
						break;
					}
				}
			}
			if ( !bSuccessSeek )
			{
				// this.n現在のトップChip = CDTXMania.DTX.listChip.Count - 1;
				this.n現在のトップChip = 0;       // 対象小節が存在しないなら、最初から再生
			}
			else
			{
				while (this.n現在のトップChip != 0 && dTX.listChip[this.n現在のトップChip].n発声時刻ms == dTX.listChip[TJAPlayer3.stage演奏ドラム画面.n現在のトップChip - 1].n発声時刻ms)
					TJAPlayer3.stage演奏ドラム画面.n現在のトップChip--;
			}
			#endregion

			#region [ 演奏開始の発声時刻msを取得し、タイマに設定 ]
			int nStartTime = (int)(dTX.listChip[this.n現在のトップChip].n発声時刻ms / (((double)TJAPlayer3.ConfigIni.n演奏速度) / 20.0));

			CSound管理.rc演奏用タイマ.tリセット();	// これでPAUSE解除されるので、次のPAUSEチェックは不要
			//if ( !this.bPAUSE )
			//{
				CSound管理.rc演奏用タイマ.t一時停止();
			//}
			CSound管理.rc演奏用タイマ.n現在時刻ms = nStartTime;
#endregion

			List<CSound> pausedCSound = new List<CSound>();
			
#region [ BGMやギターなど、演奏開始のタイミングで再生がかかっているサウンドのの途中再生開始 ] // (CDTXのt入力_行解析_チップ配置()で小節番号が+1されているのを削っておくこと)
			for ( int i = this.n現在のトップChip; i >= 0; i-- )
			{
				CDTX.CChip pChip = dTX.listChip[ i ];
				int nDuration = pChip.GetDuration();
				long n発声時刻ms = (long)(pChip.n発声時刻ms / (((double)TJAPlayer3.ConfigIni.n演奏速度) / 20.0));

				if ( ( n発声時刻ms + nDuration > 0 ) && ( n発声時刻ms <= nStartTime ) && ( nStartTime <= n発声時刻ms + nDuration ) )
				{
					if (pChip.nチャンネル番号 == 0x01 && (pChip.nチャンネル番号 >> 4) != 0xB)	// wav系チャンネル、且つ、空打ちチップではない
					{
						CDTX.CWAV wc;
						bool b = dTX.listWAV.TryGetValue( pChip.n整数値_内部番号, out wc );
						if ( !b ) continue;

						if ( ( wc.bIsBGMSound && TJAPlayer3.ConfigIni.bBGM音を発声する ) || ( !wc.bIsBGMSound ) )
						{
							TJAPlayer3.DTX[0].tチップの再生(pChip, (long)(CSound管理.rc演奏用タイマ.n前回リセットした時のシステム時刻ms) + (long)(pChip.n発声時刻ms / (((double)TJAPlayer3.ConfigIni.n演奏速度) / 20.0)));
#region [ PAUSEする ]
							int j = wc.n現在再生中のサウンド番号;
							if ( wc.rSound[ j ] != null )
							{
								wc.rSound[ j ].t再生を一時停止する();
								wc.rSound[ j ].t再生位置を変更する( nStartTime - n発声時刻ms );
								pausedCSound.Add( wc.rSound[ j ] );
							}
#endregion
						}
					}
				}
			}
			#endregion

#region [ 演奏開始時点で既に表示されているBGAとAVIの、シークと再生 ]
			if (dTX.listVD.Count > 0)
				for (int i = 0; i < dTX.listChip.Count; i++)
					if (dTX.listChip[i].nチャンネル番号 == 0x54)
						if (dTX.listChip[i].n発声時刻ms <= nStartTime)
						{
							this.actAVI.Seek(nStartTime - dTX.listChip[i].n発声時刻ms);
							this.actAVI.Start(0x54, this.actAVI.rVD);
							break;
						}
						else
						{
							this.actAVI.Seek(0);
						}


			#endregion
			#region [ PAUSEしていたサウンドを一斉に再生再開する(ただしタイマを止めているので、ここではまだ再生開始しない) ]

			if (!(TJAPlayer3.ConfigIni.b演奏速度が一倍速であるとき以外音声を再生しない && TJAPlayer3.ConfigIni.n演奏速度 != 20))
				foreach (CSound cs in pausedCSound)
				{
					cs.tサウンドを再生する();
				}
			pausedCSound.Clear();
			pausedCSound = null;
#endregion
#region [ タイマを再開して、PAUSEから復帰する ]
			CSound管理.rc演奏用タイマ.n現在時刻ms = nStartTime;
			TJAPlayer3.Timer.tリセット();						// これでPAUSE解除されるので、3行先の再開()は不要
			TJAPlayer3.Timer.n現在時刻ms = nStartTime;				// Debug表示のTime: 表記を正しくするために必要
			CSound管理.rc演奏用タイマ.t再開();
			//CDTXMania.Timer.t再開();
			this.bPAUSE = false;								// システムがPAUSE状態だったら、強制解除
			this.actPanel.Start();
#endregion
#endregion
		}

		public void t演奏中止()
		{
			this.actFO.tフェードアウト開始();
			base.eフェーズID = CStage.Eフェーズ.共通_フェードアウト;
			this.eフェードアウト完了時の戻り値 = E演奏画面の戻り値.演奏中断;
		}

		protected abstract void t進行描画_チップ_Taiko( CConfigIni configIni, ref CDTX dTX, ref CDTX.CChip pChip, int nPlayer );
		protected abstract void t進行描画_チップ_Taiko連打( CConfigIni configIni, ref CDTX dTX, ref CDTX.CChip pChip, int nPlayer );

		protected abstract void t進行描画_チップ_小節線( CConfigIni configIni, ref CDTX dTX, ref CDTX.CChip pChip, int nPlayer );
		protected void t進行描画_チップアニメ()
		{
			if( this.b初めての進行描画 )
			{

			}
			for (int i = 0; i < 2; i++)
			{
				ctChipAnime[i].t進行LoopDb();
				ctChipAnimeLag[i].t進行();
			}
		}

		protected bool t進行描画_フェードイン_アウト()
		{
			switch ( base.eフェーズID )
			{
				case CStage.Eフェーズ.共通_フェードイン:
					if ( this.actFI.On進行描画() != 0 )
					{
						base.eフェーズID = CStage.Eフェーズ.共通_通常状態;
					}
					break;

				case CStage.Eフェーズ.共通_フェードアウト:
				case CStage.Eフェーズ.演奏_STAGE_FAILED_フェードアウト:
					if ( this.actFO.On進行描画() != 0 )
					{
						return true;
					}
					break;

				case CStage.Eフェーズ.演奏_STAGE_CLEAR_フェードアウト:
					if ( this.actFOClear.On進行描画() == 0 )
					{
						break;
					}
					return true;
		
			}
			return false;
		}

		protected abstract void t進行描画_演奏情報();
		protected void t進行描画_演奏情報(int x, int y)
		{
			if ( !TJAPlayer3.ConfigIni.b演奏情報を表示しない )
			{
				this.actPlayInfo.t進行描画( x, y );
			}
		}
		protected void t進行描画_背景()
		{
			if ( this.tx背景 != null )
			{
				this.tx背景.vc拡大縮小倍率.X =(float) (1.0 / (this.tx背景.szテクスチャサイズ.Width / 1280.0));
				this.tx背景.vc拡大縮小倍率.Y =(float) (1.0 / (this.tx背景.szテクスチャサイズ.Height / 720.0));
				this.tx背景.t2D描画( TJAPlayer3.app.Device, 0, 0 );
			}
		}
		
		protected abstract void t紙吹雪_開始();
		protected abstract void t背景テクスチャの生成();
		protected void t背景テクスチャの生成( string DefaultBgFilename, Rectangle bgrect, string bgfilename )
		{
			try
			{
				if( !String.IsNullOrEmpty( bgfilename ) )
					this.tx背景 = TJAPlayer3.tテクスチャの生成( TJAPlayer3.stage選曲.r確定されたスコア.ファイル情報.フォルダの絶対パス + bgfilename );
				else
					this.tx背景 = TJAPlayer3.tテクスチャの生成( CSkin.Path( DefaultBgFilename ) );
			}
			catch (Exception e)
			{
				Trace.TraceError( e.ToString() );
				Trace.TraceError( "例外が発生しましたが処理を継続します。 (a80767e1-4de7-4fec-b072-d078b3659e62)" );
				this.tx背景 = null;
			}
		}

		public void ReSetScore(int scoreInit, int scoreDiff, int nPlayer)
		{
			//一打目の処理落ちがひどいので、あらかじめここで点数の計算をしておく。
			// -1だった場合、その前を引き継ぐ。
			int nInit = scoreInit != -1 ? scoreInit : this.nScore[nPlayer, 0];
			int nDiff = scoreDiff != -1 ? scoreDiff : this.nScore[nPlayer, 1] - this.nScore[nPlayer, 0];
			int nAddScore = 0;
			int[] n倍率 = { 0, 1, 2, 4, 8 };

			if (TJAPlayer3.DTX[nPlayer].nScoreModeTmp == 1)
			{
				for (int i = 0; i < 11; i++)
				{
					this.nScore[nPlayer, i] = (int)(nInit + (nDiff * (i)));
				}
			}
			else if (TJAPlayer3.DTX[nPlayer].nScoreModeTmp == 2)
			{
				for (int i = 0; i < 5; i++)
				{
					this.nScore[nPlayer, i] = (int)(nInit + (nDiff * n倍率[i]));

					this.nScore[nPlayer, i] = (int)(this.nScore[nPlayer, i] / 10.0);
					this.nScore[nPlayer, i] = this.nScore[nPlayer, i] * 10;

				}
			}
			else if (TJAPlayer3.DTX[nPlayer].nScoreModeTmp == 3)
				this.nScore[nPlayer, 0] = nInit;
		}
#endregion
	}
}
